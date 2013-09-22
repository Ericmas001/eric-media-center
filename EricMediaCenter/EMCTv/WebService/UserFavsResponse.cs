using EMCTv.Entities;
using System.Collections.Generic;

namespace EMCTv.WebService
{
    public class UserFavsResponse : UserResponse
    {
        private List<FavoriteTvShow> m_Shows;

        public List<FavoriteTvShow> Shows
        {
            get { return m_Shows; }
            set { m_Shows = value; }
        }
    }
}