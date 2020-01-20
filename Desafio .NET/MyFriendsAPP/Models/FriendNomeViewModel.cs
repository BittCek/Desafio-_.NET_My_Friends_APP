using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MyFriendsAPP.Models
{
    public class FriendNomeViewModel
    {
        public List<Friend> Friends { get; set; }
        public SelectList Nomes { get; set; }
        public string FriendNome { get; set; }
        public string SearchString { get; set; }
    }
}
