using KrediKartiAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KrediKartiAPI.Application.CreditCardOperations.Commands.CreateCreditCardCommand
{
    public interface ICreditCardService
    {
        List<CreditCard> GetCards();
        CreditCard AddCreditCard(CreditCard card);
        CreditCard GetCard(string id);
        void DeleteCard(string id);
        CreditCard UpdateCard(CreditCard card);
        CreditCard GetUserCard(int id);
    }
}
