package com.emc.watchseries;

import java.util.HashMap;
import java.util.Map;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import android.app.ListActivity;
import android.app.ProgressDialog;
import android.content.Intent;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.ListView;
import android.widget.Toast;

import com.emc.util.ContactWebservice;

public class WSSelectSerieActivity extends ListActivity
{
    WSMenu ws_menu;
    public Map<String, String> availables;
    ProgressDialog dialog;

    public void onCreate(Bundle icicle)
    {
        super.onCreate(icicle);
        ws_menu = new WSMenu(this);
        Bundle b = getIntent().getExtras();
        String url = b.getString("url");
        populate(url);
    }

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

    public void populate(String url)
    {
        String[] values = new String[0];
        ArrayAdapter<String> adapter = new ArrayAdapter<String>(this, android.R.layout.simple_list_item_1, values);
        setListAdapter(adapter);
        dialog = new ProgressDialog(WSSelectSerieActivity.this);
        dialog.setCancelable(false);
        dialog.setMessage("Getting Series ...");
        dialog.setProgressStyle(ProgressDialog.STYLE_SPINNER);
        dialog.show();
        ContactWebservice.CallWS(this, "onPostExecute", url);
    }

    @Override
    protected void onListItemClick(ListView l, View v, int position, long id)
    {

        Intent intent = new Intent();
        String item = (String) getListAdapter().getItem(position);
        intent.setClass(this, WSTvShowActivity.class);
        Bundle b = new Bundle();
        b.putString("key", availables.get(item));
        b.putString("title", item);
        intent.putExtras(b);
        if (intent != null)
            startActivity(intent);

    }

    public void onPostExecute(String result, Exception exception)
    {
        if (result != null)
        {
            JSONArray json;
            try
            {
                json = new JSONArray(result);
                availables = new HashMap<String, String>();
                String[] values = new String[json.length()];
                for (int i = 0; i < json.length(); ++i)
                {
                    JSONObject o = json.getJSONObject(i);
                    String id = o.getString("ShowName");
                    String label = o.getString("ShowTitle");
                    values[i] = label;
                    availables.put(label, id);
                }

                ArrayAdapter<String> adapter = new ArrayAdapter<String>(WSSelectSerieActivity.this, android.R.layout.simple_list_item_1, values);
                setListAdapter(adapter);
            }
            catch (JSONException e)
            {
                Toast.makeText(WSSelectSerieActivity.this, e.toString(), Toast.LENGTH_LONG).show();
            }
        }
        else
            Toast.makeText(WSSelectSerieActivity.this, exception.toString(), Toast.LENGTH_LONG).show();
        dialog.cancel();
    }
}