using System;
using Jil;

namespace dhis
{
  class Program
  {
    static void Main(string[] args)
    {
      Client dhis2 = new Client("https://play.dhis2.org/2.29", "admin", "district");

      //Get the first page of org units
      var result = dhis2.Get("organisationUnits");

      Console.WriteLine(result.pager.total);
      foreach (var orgUnit in result.organisationUnits)
      {
        Console.WriteLine($"{orgUnit.id}:{orgUnit.displayName}");
      }

      //Get a single org unit
      string ouId = result.organisationUnits[0].id;
      Console.WriteLine(ouId);
      string url = $"organisationUnits/{ouId}";
      Console.WriteLine(url);
      var single = dhis2.Get(url);

      Console.WriteLine(single);
    }
  }
}
