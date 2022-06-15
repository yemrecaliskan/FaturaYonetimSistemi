using KrediKartiAPI.Application.CreditCardOperations.Commands.CreateCreditCardCommand;
using KrediKartiAPI.DbOperations;
using KrediKartiAPI.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KrediKartiAPI.Application.CreditCardOperations
{
    public class CreditCardServices : ICreditCardService
    {
        private readonly IMongoCollection<CreditCard> _cards;
        public CreditCardServices(IDbClient dbClient)
        {
           _cards = dbClient.GetCreditCardsCollection();
        }

        public CreditCard AddCreditCard(CreditCard card)
        {
            _cards.InsertOne(card);
            return card;
        }

        public void DeleteCard(string id)
        {
            _cards.DeleteOne(x => x.CardID == id);
        }

        public CreditCard GetCard(string id)
        {
            return _cards.Find(x => x.CardID == id).FirstOrDefault();
        }

        public List<CreditCard> GetCards()
        {
            return _cards.Find(x => x.UserID > 0).ToList();
        }

        public CreditCard GetUserCard(int id)
        {
            return _cards.Find(x => x.UserID == id).FirstOrDefault();
        }

        public CreditCard UpdateCard(CreditCard card)
        {
            GetCard(card.CardID);
            _cards.ReplaceOne(x => x.CardID == card.CardID, card);
            return card;
        }
    }
}
