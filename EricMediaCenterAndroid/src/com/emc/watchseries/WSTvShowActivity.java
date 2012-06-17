package com.emc.watchseries;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import android.app.Activity;
import android.app.ProgressDialog;
import android.content.Intent;
import android.graphics.Bitmap;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.ExpandableListAdapter;
import android.widget.ExpandableListView;
import android.widget.ExpandableListView.OnChildClickListener;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;

import com.emc.R;
import com.emc.util.ContactWebservice;
import com.emc.util.EMCExpandableListAdapter;
import com.emc.util.ImageFromURL;

public class WSTvShowActivity extends Activity implements OnChildClickListener
{
    WSMenu ws_menu;
    ImageView imgShow;
    TextView lblShow;
    TextView lblDesc;
    ProgressDialog dialog;
    private String[][] childrenN;

    @Override
    public boolean onCreateOptionsMenu(Menu menu)
    {
        ws_menu.inflateMenu(menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item)
    {
        ws_menu.performMenuItem(item);
        return super.onOptionsItemSelected(item);
    }

    @Override
    public void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        ws_menu = new WSMenu(this);
        setContentView(R.layout.ws_show);
        imgShow = (ImageView) this.findViewById(R.id.ws_show_logo);
        lblShow = (TextView) this.findViewById(R.id.ws_show_title);
        lblDesc = (TextView) this.findViewById(R.id.ws_show_desc);
        Bundle b = getIntent().getExtras();
        String key = b.getString("key");
        dialog = new ProgressDialog(this);
        dialog.setCancelable(false);
        dialog.setMessage("Loading TvShow ...");
        dialog.setProgressStyle(ProgressDialog.STYLE_SPINNER);

        dialog.show();
        ContactWebservice.CallWS(this, "onPostExecute", "http://emc.ericmas001.com/WatchSeries/GetShow/" + key);
    }

    public void onPostExecute(String result, Exception exception)
    {
        if (result != null)
        {
            JSONObject json;
            try
            {
                json = new JSONObject(result);
                lblShow.setText(json.getString("ShowTitle"));
                lblDesc.setText(json.getString("Description"));
                ExpandableListAdapter mAdapter;
                ExpandableListView epView = (ExpandableListView) findViewById(R.id.ws_show_episodes);
                epView.setOnChildClickListener(this);
                JSONArray array = json.getJSONArray("Seasons");
                String[] groups = new String[array.length()];
                String[][] children = new String[array.length()][];
                childrenN = new String[array.length()][];
                for (int i = 0; i < array.length(); ++i)
                {
                    JSONObject season = array.getJSONObject(i);
                    groups[i] = "Season " + season.getInt("SeasonNo") + " ( " + season.getInt("NbEpisodes") + " episodes)";
                    JSONArray episodes = season.getJSONArray("Episodes");
                    children[i] = new String[episodes.length()];
                    childrenN[i] = new String[episodes.length()];
                    for (int j = 0; j < episodes.length(); ++j)
                    {
                        JSONObject episode = episodes.getJSONObject(j);
                        children[i][j] = season.getInt("SeasonNo") + "x" + episode.getInt("EpisodeNo") + " - " + episode.getString("EpisodeTitle");
                        childrenN[i][j] = episode.getString("EpisodeName");
                    }
                }
                mAdapter = new EMCExpandableListAdapter(this, groups, children);
                epView.setAdapter(mAdapter);

                ImageFromURL.LoadBitmap(this, "onPostExecuteLogo", json.getString("Logo").replace(" ", "%20"));
            }
            catch (JSONException e)
            {
                Toast.makeText(this, e.toString(), Toast.LENGTH_LONG).show();
            }
        }
        else
            Toast.makeText(this, exception.toString(), Toast.LENGTH_LONG).show();
        dialog.cancel();
    }

    public boolean onChildClick(ExpandableListView parent, View v, int groupPosition, int childPosition, long id)
    {
        Intent intent = new Intent();
        String item = childrenN[groupPosition][childPosition];
        intent.setClass(this, WSEpisodeActivity.class);
        Bundle b = new Bundle();
        b.putString("key", item);
        intent.putExtras(b);
        if (intent != null)
            startActivity(intent);
        return true;
    }

    public void onPostExecuteLogo(Bitmap result, Exception exception)
    {
        if (result != null)
        {
            imgShow.setImageBitmap(result);
        }
    }
}