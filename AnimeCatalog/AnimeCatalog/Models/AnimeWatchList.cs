using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeCatalog.Models;
public class AnimeWatchList
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string AnimeName { get; set; }
    public string UserRating { get; set; }
}
