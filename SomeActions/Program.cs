using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TrelloNet;

namespace SomeActions
{
  class Program
  {



    static void Main(string[] args)
    {
      ITrello trello = new Trello(Configuration.DeveloperKey, true);

      var url = trello.GetAuthorizationUrl("MyApp", Scope.ReadWrite);

      //trello.
      //httpWebRequest.Proxy.Credentials = CredentialCache.DefaultCredentials;
      //var cc = CredentialCache.DefaultCredentials;


      trello.Authorize(Configuration.UserToken);
      

      // Get the authenticated member
      Member me = trello.Members.Me();
      //Console.WriteLine(me.FullName);


      

      var myBoards = trello.Boards.ForMember(me);


      var myBoard = myBoards.Where(b=>b.Name == "WorkBoard").FirstOrDefault();
      var list = trello.Lists.ForBoard(myBoard).FirstOrDefault();
      trello.Cards.Add("Новый картен", list);

      /*var board = trello.Boards.WithId("5a5c32dcac1b363264c4e25a");
      var lists = trello.Lists.ForBoard(board); //Where(l=>l.Name == "Неделя 29.01 - 02.02").FirstOrDefault()

      foreach (var list in lists)
      {
        var membersTotalPlan = new Dictionary<string, double>(); // MemberId

        Console.WriteLine(list.Name + ":");

        var cards = trello.Cards.ForList(list);

        if (cards.Count() == 0)
        {
          Console.WriteLine("Нихт картен");
        }

        foreach (var card in cards)
        {
          //Console.WriteLine(card.Name);
          int memCount = card.IdMembers.Count;

          var pd = trello.Cards.CardPluginData(card.Id);
          int cardPoints = 0;
          if (pd.Count > 0)
          {
            cardPoints = pd.Where(p => p.IdPlugin == "59d4ef8cfea15a55b0086614").FirstOrDefault().ParsedValue.Points;
          }

          foreach (string memId in card.IdMembers)
          {
            if (membersTotalPlan.Keys.Contains(memId))
            {
              membersTotalPlan[memId] += (Convert.ToDouble(cardPoints) / memCount);
            }
            else
            {
              membersTotalPlan.Add(memId, Convert.ToDouble(cardPoints) / memCount);
            }

            //var cardMember = trello.Members.WithId(memId);
            //Console.Write(cardMember.FullName + " ");
            //var tc = trello.Cards.WithId(card.Id); // 5a6aeba0a2cd0bebfce3d617
          }


          //Console.WriteLine(card.);
        }

        foreach (string memId in membersTotalPlan.Keys)
        {
          var cardMember = trello.Members.WithId(memId);
          Console.WriteLine(string.Format("{0}: {1}", cardMember.FullName, membersTotalPlan[memId]));
        }
        Console.WriteLine();
      }*/
      


      /*
      var lists = trello.Lists.ForBoard(myBoard).Where(l=>l.Name != "TO DO");

      foreach (var list in lists)
      {
        Console.WriteLine(list.Name);
        var cards = trello.Cards.ForList(list);
        foreach (var card in cards)
        {
          Console.WriteLine(card.Name);
          //Console.Write(string.Join(", ", card.IdMembers));
          //Console.WriteLine(": ");
          foreach (var memId in card.IdMembers)
          {
            var cardMember = trello.Members.WithId(memId);
            Console.Write(cardMember.FullName + " ");
          }

          //Console.WriteLine(card.);
        }


        Console.WriteLine();
      }
       */

      //Console.WriteLine(me.FullName);

      // Get a board
      //Board theTrelloDevBoard = trello.Boards.WithId("4d5ea62fd76aa1136000000c");
      //Console.WriteLine(theTrelloDevBoard.Name);

      Console.ReadKey();
      /*var myBoard = trello.Boards.Add("My Board");

      var todoList = trello.Lists.Add("To Do", myBoard);
      trello.Lists.Add("Doing", myBoard);
      trello.Lists.Add("Done", myBoard);

      trello.Cards.Add("My card", todoList);

      foreach (var list in trello.Lists.ForBoard(myBoard))
          Console.WriteLine(list.Name);*/
    }
  }
}
