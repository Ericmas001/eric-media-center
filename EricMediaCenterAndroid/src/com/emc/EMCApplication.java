package com.emc;

import android.app.Application;
import android.content.Context;

public class EMCApplication extends Application
{

    private static EMCApplication instance;

    public EMCApplication()
    {
        instance = this;
    }

    public static Context getContext()
    {
        return instance;
    }

    private boolean m_IsAGuest;

    public boolean isAGuest()
    {
        return m_IsAGuest;
    }

    public void setIsAGuest(boolean b)
    {
        m_IsAGuest = b;
    }
}
