using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Tenis_opdracht.DTO.Member;

namespace Tenis_opdracht.Api
{
    public static class MemberAPI
    {
        public static async Task<List<MemberDTO>> GetMembers(params string[] args)
        {
            string arguments = "";
            if (args.Length > 0)
            {
                arguments += "?" + string.Join("&", args);
            }
            string fullUri = $"{ApiHelper.BASEURL}member";
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(fullUri + arguments))
            {
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<List<MemberDTO>>();
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static async void CreateMember(MemberCreateDTO member)
        {
            string fullUri = $"{ApiHelper.BASEURL}member/create";
            using (HttpResponseMessage response = await ApiHelper.ApiClient.PostAsJsonAsync(fullUri, member))
            {
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
