package com.emc;

import android.app.ListActivity;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.ListView;

import com.emc.test.LoginActivity;
import com.emc.test.TestAppActivity;
import com.emc.tvschedule.TVSSelectDayActivity;
import com.emc.util.PrefUtil;
import com.emc.watchseries.WSLoginActivity;
import com.emc.watchseries.WSSelectSerieActivity;

public class MainAppActivity extends ListActivity
{
    public void onCreate(Bundle icicle)
    {
        super.onCreate(icicle);
        String[] values = new String[] { "TvSchedule", "Test", "Login", "WatchSeries" };
        ArrayAdapter<String> adapter = new ArrayAdapter<String>(this, android.R.layout.simple_list_item_1, values);
        setListAdapter(adapter);
    }

    @Override
    protected void onListItemClick(ListView l, View v, int position, long id)
    {

        final MainAppActivity currentActivity = this;
        Intent intent = new Intent();
        String item = (String) getListAdapter().getItem(position);
        if (item.equals("TvSchedule"))
            intent.setClass(currentActivity, TVSSelectDayActivity.class);
        else if (item.equals("Test"))
            intent.setClass(currentActivity, TestAppActivity.class);
        else if (item.equals("Login"))
            intent.setClass(currentActivity, LoginActivity.class);
        else if (item.equals("WatchSeries"))
        {
            if (PrefUtil.getBool("isAGuest", false))
            {
                intent.setClass(currentActivity, WSSelectSerieActivity.class);
                Bundle b = new Bundle();
                b.putString("url", "http://emc.ericmas001.com/WatchSeries/GetPopulars");
                intent.putExtras(b);
            }
            else
                intent.setClass(currentActivity, WSLoginActivity.class);
        }
        else
            intent = null;
        if (intent != null)
            startActivity(intent);
    }
}