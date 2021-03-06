package com.emc.test;

import android.app.Activity;
import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.TextView;

import com.emc.R;

public class MyListAdapter extends BaseAdapter
{
    private Activity activity;
    private String[] list1;
    private String[] list2;
    private static LayoutInflater inflater = null;

    public MyListAdapter(Activity a, String[] list1, String[] list2)
    {
        this.activity = a;
        this.list1 = list1;
        this.list2 = list2;
        MyListAdapter.inflater = (LayoutInflater) activity.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
    }

    public int getCount()
    {
        return list1.length;
    }

    public Object getItem(int position)
    {
        return position;
    }

    public long getItemId(int position)
    {
        return position;
    }

    public static class ViewHolder
    {
        public TextView text1;
        public TextView text2;
        // public ImageView image;
    }

    public View getView(int position, View convertView, ViewGroup parent)
    {
        View vi = convertView;
        ViewHolder holder;
        if (convertView == null)
        {

            vi = inflater.inflate(R.layout.grid_list_layout, null);

            holder = new ViewHolder();
            holder.text1 = (TextView) vi.findViewById(R.id.item1);
            holder.text2 = (TextView) vi.findViewById(R.id.item2);
            // holder.image = (ImageView)vi.findViewById(R.id.icon);

            vi.setTag(holder);
        }
        else
            holder = (ViewHolder) vi.getTag();

        holder.text1.setText(this.list1[position]);
        holder.text2.setText(this.list2[position]);
        // holder.image.setImageResource(this.image[position]);

        return vi;
    }
}
