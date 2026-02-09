using Application.interfaces;
using Domain.Entities;
using Application.DTO;
using Infrastructure.Data;
using Azure.Core;

namespace Infrastructure.Repositories
{
    public class CampaignRepository : ICampaign
    {
        private readonly ApplicationDbContext _dbContext;

        public CampaignRepository(ApplicationDbContext context)
        {
            _dbContext = context;
        }
        // Retrieving campaigns
        public List<Campaign> GetAllCampaigns()
        {
            List<Campaign> _campaigns = _dbContext.Campaigns.ToList();
            return _campaigns;
        }  
        public Campaign GetCampaignById(int id)
        {
           return _dbContext.Campaigns.FirstOrDefault(c=>c.Id==id);
        }
        public void CreateCampaign(CampaignCreateDTO campaignDTO)
        {
            Campaign campaign = new Campaign
            {
                Name = campaignDTO.Name,
                type = campaignDTO.type,
                Description = campaignDTO.Description,
                Budget = campaignDTO.Budget,
                StartDate = campaignDTO.StartDate,
                EndDate = campaignDTO.EndDate,
                CreatedAt = DateTime.Now,
                CreatedById = 1
            };
            _dbContext.Campaigns.Add(campaign);
            _dbContext.SaveChanges();
        }

        public void UpdateCampaign(int id, CampaignUpdateDTO campaignDTO)
        {
            var campaign = _dbContext.Campaigns.Find(id);
            if (campaign == null) return;

                campaign.type = campaignDTO.type;
                campaign.Description = campaignDTO.Description;
                campaign.Budget = campaignDTO.Budget;
                campaign.Status = campaignDTO.Status;

                _dbContext.SaveChanges();
        }
    }
}