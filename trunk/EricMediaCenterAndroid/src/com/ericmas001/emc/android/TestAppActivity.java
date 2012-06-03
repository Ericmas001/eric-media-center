package com.ericmas001.emc.android;

import org.json.JSONException;
import org.json.JSONObject;

import android.app.Activity;
import android.content.Intent;
import android.net.Uri;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.widget.Toast;

public class TestAppActivity extends Activity {

    @Override
    public boolean onCreateOptionsMenu(Menu menu)
    {
        MenuInflater inflater = getMenuInflater();
        inflater.inflate(R.menu.appmenu, menu);
        return true;
    }
    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.test);
    }
    public void openWebsite(View view) {
    	String url = getString(R.string.website);  
    	Intent i = new Intent(Intent.ACTION_VIEW);  
    	i.setData(Uri.parse(url));  
    	startActivity(i);  
    }

    public void onPostExecute(String result, Exception exception) {
    	if( result != null )
    	{
    		JSONObject json;
			try {
				json = new JSONObject(result);
    		Toast.makeText(TestAppActivity.this, json.getString("value"), Toast.LENGTH_SHORT).show();
			} catch (JSONException e) {
        		Toast.makeText(TestAppActivity.this, e.toString(), Toast.LENGTH_LONG).show();
			}
    	}
    	else
    		Toast.makeText(TestAppActivity.this, exception.toString(), Toast.LENGTH_LONG).show();
    }
    public void getTime(View view) {
		ContactWebservice.CallWS(this, "onPostExecute", "http://emc.ericmas001.com/TimeService2/CurrentTime");
    }
    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
    	if(item.getItemId() == R.id.itAbout)
    	{
            Intent intent = new Intent();
            intent.setClass(this, AboutActivity.class);
            startActivity(intent);
    	}

    	return super.onOptionsItemSelected(item);
    }
}