package com.emc.test;

import org.json.JSONException;
import org.json.JSONObject;

import android.app.Activity;
import android.os.Bundle;
import android.view.View;
import android.widget.EditText;
import android.widget.Toast;

import com.emc.R;
import com.emc.util.ContactWebservice;

public class LoginActivity extends Activity {
	EditText txtUser;
	 EditText txtPass;
    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.login);
        txtUser=(EditText)this.findViewById(R.id.txtUser);
        txtPass=(EditText)this.findViewById(R.id.txtPass);
    }
    public void loginClick(View view) {
		ContactWebservice.CallWS(this, "onPostExecute", "http://emc.ericmas001.com/User/Connect/"+txtUser.getText()+"/"+txtPass.getText());
    }
    public void onPostExecute(String result, Exception exception) {
    	if( result != null )
    	{
    		JSONObject json;
			try {
				json = new JSONObject(result);
    		Toast.makeText(LoginActivity.this, json.getString("success"), Toast.LENGTH_SHORT).show();
			} catch (JSONException e) {
        		Toast.makeText(LoginActivity.this, e.toString(), Toast.LENGTH_LONG).show();
			}
    	}
    	else
    		Toast.makeText(LoginActivity.this, exception.toString(), Toast.LENGTH_LONG).show();
    }
}