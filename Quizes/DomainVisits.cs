using System.Collections.Generic;

namespace MainDSA.Quizes
{
    public static class DomainVisits
    {
        public static IList<string> SubdomainVisits(string[] cpDomains)
        {
            Dictionary<string, int> mapSubDomain = new Dictionary<string, int>();
            List<string> results = new List<string>();

            foreach (var cpDomain in cpDomains)
            {
                var domainVisitData = cpDomain.Split(' ');
                var domainData = domainVisitData[1];
                var domainVisitCount = int.Parse(domainVisitData[0]);
                var subDomains = GetSubDomains(domainData);
                foreach (var subDomain in subDomains)
                {
                    if (mapSubDomain.ContainsKey(subDomain))
                    {
                        mapSubDomain[subDomain] = mapSubDomain[subDomain] + domainVisitCount;
                    }
                    else
                    {
                        mapSubDomain.Add(subDomain, domainVisitCount);
                    }
                }
            }
            foreach (var keyValuePair in mapSubDomain)
            {
                results.Add(keyValuePair.Value.ToString() + " " + keyValuePair.Key);
            }
            return results;
        }

        private static string[] GetSubDomains(string domainData)
        {
            string[] subDomains = domainData.Split('.');
            for (int i = 0; i < subDomains.Length; i++)
            {
                var subDomain = subDomains[i];
                for (int j = i + 1; j < subDomains.Length; j++)
                {
                    subDomain = subDomain + "." + subDomains[j];
                }
                subDomains[i] = subDomain;
            }
            return subDomains;
        }
    }
}
