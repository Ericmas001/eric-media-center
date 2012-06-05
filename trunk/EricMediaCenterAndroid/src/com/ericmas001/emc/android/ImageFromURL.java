package com.ericmas001.emc.android;

import java.io.InputStream;
import java.lang.reflect.InvocationTargetException;
import java.lang.reflect.Method;

import org.apache.http.HttpResponse;
import org.apache.http.client.methods.HttpGet;
import org.apache.http.client.params.ClientPNames;
import org.apache.http.impl.client.DefaultHttpClient;

import android.content.Context;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.os.AsyncTask;
import android.widget.Toast;

public class ImageFromURL extends AsyncTask<String, Void, Bitmap>{
	@SuppressWarnings("rawtypes")
	public static final Class[] PARAMETER_TYPES = new Class[]{ Bitmap.class, Exception.class};

	private Object m_Obj;
	private Method m_Method;
	private Exception m_Exception;

	public static <T extends Context> void LoadBitmap( T obj, String method, String url )
	{
		LoadBitmap(obj,method,url,obj);
	}
	public static <T extends Context> void LoadBitmap( T obj, String method, String url, Object caller )
	{
		try {
			new ImageFromURL(caller,
					caller.getClass().getMethod(method,
							ImageFromURL.PARAMETER_TYPES))
					.execute(url);
		} catch (NoSuchMethodException e) {
			Toast.makeText(obj, e.toString(), Toast.LENGTH_LONG).show();
		}
	}
	
	public ImageFromURL( Object obj, Method method )
	{
		m_Obj = obj;
		m_Method = method;
	}
	@Override
	protected Bitmap doInBackground(String... urls) {
		DefaultHttpClient client = new DefaultHttpClient();
		client.getParams().setParameter(
				ClientPNames.ALLOW_CIRCULAR_REDIRECTS, true);

		HttpGet request = new HttpGet(urls[0]);

		try {
			HttpResponse response = client.execute(request);
			InputStream stream = response.getEntity().getContent();
			if(stream != null)
	            return BitmapFactory.decodeStream(stream);
			return null;
		} catch (Exception e) {
			m_Exception = e;
			return null;
		}
	}

	protected void onPostExecute(Bitmap result) {
		Object[] parameters = new Object[2];
        parameters[0] = result;
        parameters[1] = m_Exception;
        try {
			m_Method.invoke(m_Obj, parameters);
		} catch (IllegalArgumentException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} catch (IllegalAccessException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} catch (InvocationTargetException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}
}
