using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealmDesktop.Model
{
public class Person: RealmObject
{
    public string Name { get; set; }
    public string Surname { get; set; }
}
}
