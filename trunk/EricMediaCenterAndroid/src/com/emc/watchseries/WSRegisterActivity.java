package com.emc.watchseries;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.TextView;

import com.emc.R;
import com.emc.util.PrefUtil;

public class WSRegisterActivity extends Activity
{
    @Override
    public void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        // Set View to register.xml
        setContentView(R.layout.ws_register);

        TextView loginScreen = (TextView) findViewById(R.id.link_to_login);
        TextView guestScreen = (TextView) findViewById(R.id.link_to_enter_as_guest);

        // Listening to Login Screen link
        loginScreen.setOnClickListener(new View.OnClickListener()
        {

            public void onClick(View arg0)
            {
                // Switching to Login screen
                Intent i = new Intent(getApplicationContext(), WSLoginActivity.class);
                startActivity(i);
                finish();
            }
        });
        // Listening to enter guest link
        guestScreen.setOnClickListener(new View.OnClickListener()
        {

            public void onClick(View v)
            {
                PrefUtil.set("isAGuest", true);
                Intent intent = new Intent();
                intent.setClass(WSRegisterActivity.this, WSSelectSerieActivity.class);
                Bundle b = new Bundle();
                b.putString("url", "http://emc.ericmas001.com/WatchSeries/GetPopulars");
                intent.putExtras(b);
                startActivity(intent);
                finish();
            }
        });
    }
}