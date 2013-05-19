using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace EMCTv
{
    public class UserFavsResponse : UserResponse
    {
        List<FavoriteTvShow> m_Shows;

        public List<FavoriteTvShow> Shows
        {
            get { return m_Shows; }
            set { m_Shows = value; }
        }
    }
}