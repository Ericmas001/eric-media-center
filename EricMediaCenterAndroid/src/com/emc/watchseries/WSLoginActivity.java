package com.emc.watchseries;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.TextView;

import com.emc.R;

public class WSLoginActivity extends Activity
{
    @Override
    public void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.ws_login);

        TextView registerScreen = (TextView) findViewById(R.id.link_to_register);
        TextView guestScreen = (TextView) findViewById(R.id.link_to_enter_as_guest);

        // Listening to register new account link
        registerScreen.setOnClickListener(new View.OnClickListener()
        {

            public void onClick(View v)
            {
                // Switching to Register screen
                Intent i = new Intent(getApplicationContext(), WSRegisterActivity.class);
                startActivity(i);
            }
        });
        // Listening to enter guest link
        guestScreen.setOnClickListener(new View.OnClickListener()
        {

            public void onClick(View v)
            {
                Intent intent = new Intent();
                intent.setClass(WSLoginActivity.this, WSSelectSerieActivity.class);
                Bundle b = new Bundle();
                b.putString("url", "http://emc.ericmas001.com/WatchSeries/GetPopulars");
                intent.putExtras(b);
                startActivity(intent);
                finish();
            }
        });
    }
}