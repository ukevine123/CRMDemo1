using Domain.Entities;
using Application.interfaces;
using Application.DTO;
namespace Application.Services.Campaigns
{
    public class CampaignService : ICampaignService
    {
        private readonly ICampaign _campaign;

        //constructor

        public CampaignService(ICampaign campaign)
        {
            _campaign = campaign;
        }
       public List<Campaign> GetAllCampaigns()
       {
          List<Campaign> _campaigns = _campaign.GetAllCampaigns();
          return _campaigns;
       }


        public Campaign GetCampaignById(int id)
        {
           return _campaign.GetCampaignById(id);
        }

        public void CreateCampaign(CampaignCreateDTO campaignDTO)
        {
            _campaign.CreateCampaign(campaignDTO);
        }
        public void UpdateCampaign(int id, CampaignUpdateDTO campaignDTO)
        {
            _campaign.UpdateCampaign(id, campaignDTO);
        }
    }
}