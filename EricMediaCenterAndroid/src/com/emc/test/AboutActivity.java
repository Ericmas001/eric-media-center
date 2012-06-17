package com.emc.test;

import android.app.Activity;
import android.os.Bundle;
import android.widget.ListView;

import com.emc.R;

public class AboutActivity extends Activity
{
    private String[] list1 = { "Application", "Version", "Author", "Author Mail", "Website" };
    private String[] list2 = { "Eric Media Center", "0.2", "Eric Masse", "ericmas001@gmail.com", "http://code.google.com/p/eric-media-center/" };

    /** Called when the activity is first created. */
    @Override
    public void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.about);

        ListView lv = (ListView) findViewById(R.id.lvResult);

        MyListAdapter listAdapter = new MyListAdapter(this, list1, list2);
        lv.setAdapter(listAdapter);
    }

}