// Poker Hand Showdown Assessment Solution
/*
  Name :- Jagroop Singh
  Date :- 23 Nov 2022

  Assumptions:-
  1. For Three of A kind Case assume we found no winner for is four of a Kind.
  2. For One Pair Case assume we found no winner for two of a Kind and there is only one pair of cards with same faces.

  Basic Gist of the Algorithm :-
  Create Players and assign their cards.
  Check flush. continue if no winner found.
  check three of a kind? continue if no winner found
  check One pain. continue if no winner found
  at last we check Hishest card and resolve the Ties.

  HOW TO RUN :- 
  Project in VS Code and write the following in Terminal
  dotnet run


  TODO :-
  Refine the Main

*/
using System;
using System.Collections;
class Game
{ 
  class Card
  {
    public String Face { get; } // Card’s face ("Ace", "2", ...)
    public String Suit { get; } // Card’s suit ("Hearts", "Spades", ...)
    public int Value { get; } // Card’s value ("3", "4", ...)
    // this hashmap contains Mapping of card weight to face value
    public Dictionary<String, int> hash = new Dictionary<String, int>(13){{"A", 14} , {"K", 13}, {"Q", 12}, {"J", 11}, {"10", 10}, {"9", 9}, {"8", 8},{"7", 7},{"6", 6}, {"5", 5}, {"4", 4}, {"3", 3}, {"2", 2}};     

    //two-parameter constructor initializes card's Face and Suit
    public Card(String face, String suit)
    {
      Face = face; // initialize face of card
      Suit = suit; // initialize suit of card
      Value = hash[face]; //initialize value of card
    }
    // return string representation of Card
    public override String ToString() => $"{Face,2} {Suit} ";
  }

  //PROGRAM STARTS HERE
  static void Main()
  {
    //Suits are in this Order - H D C S
    String[] suits = { '\u2665'.ToString(),'\u2666'.ToString(), '\u2663'.ToString(),'\u2660'.ToString() };
    Dictionary<Char, String> suitHash = new Dictionary<Char, String>(){{'H', suits[0]},{'D', suits[1]},{'C', suits[2]},{'S', suits[3]}};
    
    Dictionary<Card[], String> PlayerHash = new Dictionary<Card[], String>();

    //Creating new players and assigning them their cards 
    Card[] Joe = new Card[5];
    Card[] Jen = new Card[5];
    Card[] Bob = new Card[5];
    Card[] Sally = new Card[5];

    Card[] temp = new Card[5];

    PlayerHash.Add(Joe, "Joe");
    PlayerHash.Add(Jen, "Jen");
    PlayerHash.Add(Bob, "Bob");
    PlayerHash.Add(Sally, "Sally");
    
    //Joe: 8S, 8D, AD, QD, JH
    Joe[0] = new Card("8", suitHash['S']);
    Joe[1] = new Card("8", suitHash['D']);
    Joe[2] = new Card("A", suitHash['D']);
    Joe[3] = new Card("Q", suitHash['D']);
    Joe[4] = new Card("J", suitHash['H']);

    //Jen: 5C, 7D, 9H, 9S, QS
    Jen[0] = new Card("5", suitHash['C']);
    Jen[1] = new Card("7", suitHash['D']);
    Jen[2] = new Card("9", suitHash['H']);
    Jen[3] = new Card("9", suitHash['S']);
    Jen[4] = new Card("Q", suitHash['S']);

    //Bob: AS, QS, 8S, 6S, 4S
    Bob[0] = new Card("A", suitHash['S']);
    Bob[1] = new Card("Q", suitHash['S']);
    Bob[2] = new Card("8", suitHash['S']);
    Bob[3] = new Card("6", suitHash['S']);
    Bob[4] = new Card("4", suitHash['S']);
    
    //Sally: 4S, 4H, 3H, QC, 8C
    Sally[0] = new Card("4", suitHash['H']);
    Sally[1] = new Card("4", suitHash['H']);
    Sally[2] = new Card("3", suitHash['H']);
    Sally[3] = new Card("Q", suitHash['C']);
    Sally[4] = new Card("8", suitHash['C']);
    //----------------------------------------------------
          //TEST CASES

    //----------------------------------------------------
    //TEST for Hand 1
    //Joe: 8S, 8D, AD, QD, JH
    //Bob: AS, QS, 8S, 6S, 4S
    //Sally: 4S, 4H, 3H, QC, 8C
    Console.WriteLine("Test for Hand 1: ");
    Console.Write("Joe: "); showCards(Joe);
    Console.Write("Bob: "); showCards(Bob);
    Console.Write("Sally: "); showCards(Sally);

    if(flushCheck(Joe, Bob, Sally, PlayerHash)){
      Console.WriteLine("FlushCheck");
    }else if(threeKindCheck(Joe, Jen, Bob, PlayerHash)){
      Console.WriteLine("ThreeKindCheck");
    }else if(onePairCheck(Joe, Jen, Bob, PlayerHash)){
      Console.WriteLine("OnePairCheck");
    }else {
      highCardCheck(Joe, Jen, Bob, PlayerHash);
      Console.WriteLine("HigheshCheck");
    }
    //---------------------------------------------------
    Joe[0] = new Card("Q", suitHash['D']);
    Joe[1] = new Card("8", suitHash['D']);
    Joe[2] = new Card("K", suitHash['D']);
    Joe[3] = new Card("7", suitHash['D']);
    Joe[4] = new Card("3", suitHash['D']);
    Sally[0] = new Card("4", suitHash['S']);
    Sally[1] = new Card("4", suitHash['H']);
    Sally[2] = new Card("3", suitHash['H']);
    Sally[3] = new Card("Q", suitHash['C']);
    Sally[4] = new Card("8", suitHash['C']);
    
    //TEST for Hand 2
    /*
    Joe: QD, 8D, KD, 7D, 3D
    Bob: AS, QS, 8S, 6S, 4S
    Sally: 4S, 4H, 3H, QC, 8C
    */
 

    Console.WriteLine("Test for Hand 2: ");
    Console.Write("Joe: "); showCards(Joe);
    Console.Write("Bob: "); showCards(Bob);
    Console.Write("Sally: "); showCards(Sally);

    if(flushCheck(Joe, Bob, Sally, PlayerHash)){
      Console.WriteLine("FlushCheck ");
    }else if(threeKindCheck(Joe, Bob, Sally, PlayerHash)){
      Console.WriteLine("ThreeKindCheck ...");
    }else if(onePairCheck(Joe, Bob, Sally, PlayerHash)){
      Console.WriteLine("OnePairCheck ...");
    }else if(highCardCheck(Joe, Bob, Sally, PlayerHash)){
      Console.WriteLine("HigheshCheck ...");
    }

    Console.WriteLine("Test Cases FINISH -----------------------------");
    Console.WriteLine();
    
    //----------------------------------------------------

    Console.Write("Joe: "); showCards(Joe); 
    if(isFlush(Joe))Console.WriteLine("Joe is Flush"); 

    Console.Write("Jen : "); showCards(Joe);
    if(isFlush(Jen))Console.WriteLine("Jen is Flush"); 

    Console.Write("Bob : "); showCards(Bob);
    if(isFlush(Bob))Console.WriteLine("Bob is Flush"); 
   
    
    // Console.Write("Bob : "); showCards(Bob);
    // if(isThreeOfaKind(Bob))Console.WriteLine("Bob is Three of a Kind");
    Console.Write("Sally : "); showCards(Sally);
    if(isThreeOfaKind(Sally))Console.WriteLine("Sally is Three of a Kind");

    if(isThreeOfaKind(Bob) && isThreeOfaKind(Sally)){
      Console.WriteLine("Three of a Kind TIE");
      String won = PlayerHash[threeOfaKind_Tie(Bob, Sally)];
      Console.WriteLine(won + " is the WINNER");
    }

  }

  // FUNCTIONS 
  //--------------------------------------
  //showCards function will print the cards of player
  static void showCards(Card[] cards) {
    foreach (Card card in cards) {
      Console.Write(card);
    }
    Console.WriteLine();
  }

  // CASE 1 
  //Is Flush Function will return true if all cards are the same suit
  static bool isFlush(Card[] cards)
  {
    //implement the logic
    //for loop comparing hand[] with hand [1..<4]
    for (int i = 0; i < 4; i++) {
      if (cards[i].Suit == cards[i + 1].Suit) {
        continue;
      }
      //if i found a card of a different suit 
      else {
        return false;
      }
    }
    //return false
    return true;
  }

  // Case 1.1 
  // Flush Tie Function
  // This funtion will run when two Joe tie in Flush competiton
  static Card[] flushTie(Card[] A, Card[] B){
    int[] cards_of_A = new int[5];
    int[] cards_of_B = new int[5];
    
    for(int i=0; i<5; i++){
      cards_of_A[i]= A[i].Value;
      cards_of_B[i]= B[i].Value;
    }

    // Sorting Joe cards to get hightes face value card
    Array.Sort(cards_of_A); Array.Reverse(cards_of_B);
    Array.Sort(cards_of_A);Array.Reverse(cards_of_B);
    
    for(int i=0; i<5; i++){
      if(cards_of_A[i] == cards_of_B[i]){
        continue;
      }else if(cards_of_A[i] > cards_of_B[i]){
        return A;
      } else{
        return B;
      }
    }
    return A;
  }

  //Case 2. Is ThreeOfAKind will return true if found 3 cards of same face
  static Boolean isThreeOfaKind(Card[] cards){
    int[] faceCount= new int[15]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
    for(int i=0; i<cards.Length; i++){
      faceCount[cards[i].Value]++;
    }
    foreach(int i in faceCount){
      if( i == 3) return true;
    }
    return false;
  }


  //Case 2.1 Function to resolve if two players are three of a kind tie.
  static Card[] threeOfaKind_Tie(Card[] A, Card[] B) {
    //Assinging temporary winner
    Card[] winner =A;
    const int NumberOfCards = 5;
    int faceA = -1, faceB = -1;
    
    // suitHash will contain 1:1 mapping of faces and thier count in player's card
    // we will use this count to get ThreeOfAKind Suit
    int[] faceCountA= new int[15]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
    int[] faceCountB= new int[15]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};

    for(int i=0; i < NumberOfCards ; i++){
      faceCountA[A[i].Value]++;
      faceCountB[B[i].Value]++;
    }
    for(int i=0; i< faceCountA.Length; i++){
      if( faceCountA[i] == 3) faceA= A[faceCountA[i]].Value;
    }
    for(int i=0; i< faceCountB.Length; i++){
      if( faceCountB[i] == 3) faceB= B[faceCountA[i]].Value;
    }
    
    //Logic to find if A and B are both three of a Kind
    if(faceA > faceB){
      return A;
    } else if(faceB > faceA){
      return B;
    }
    //if the face cards are same then we check 4th and 5th card to find the winner 
    else{
      int[] remA =new int[0];
      for(int i=0; i<NumberOfCards; i++){
        if(A[i].Value!= faceA)remA.Append(A[i].Value);
      }
      Array.Sort(remA); 
      int[] remB = new int[0]; 
      for(int i=0; i<NumberOfCards; i++){
        if(B[i].Value!= faceB)remB.Append(B[i].Value);
      }
      Array.Sort(remB);

      for(int i= remA.Length-1; i>=0; i--){
        if(remA[i] == remB[i]){
          continue ;
        } else if(remA[i] > remB[i]){
          winner = A;
          return A;
        } else {
          winner = B;
          return B;
        }
      }
    }
    return winner;
  }

  //Case 2. Is onePair will return true if found 2 cards of same face value
  static Boolean isOnePair(Card[] cards){
    int[] faceCount= new int[15]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
    for(int i=0; i<cards.Length; i++){
      faceCount[cards[i].Value]++;
    }
    foreach(int i in faceCount){
      if( i == 2) return true;
    }
    return false;
  }

  //Case 2.1 Function to resolve if two players are three of a kind tie.
  static Card[] onePair_Tie(Card[] A, Card[] B) {
    //Assinging temporary value to winner
    Card[] winner =A;
    const int NumberOfCards = 5;
    int faceA = -1, faceB = -1;
    
    // suitHash will contain 1:1 mapping of faces and thier count in player's card
    // we will use this count to get ThreeOfAKind Suit
    int[] faceCountA= new int[15]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
    int[] faceCountB= new int[15]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};

    for(int i=0; i < NumberOfCards ; i++){
      faceCountA[A[i].Value]++;
      faceCountB[B[i].Value]++;
    }
    for(int i=0; i< faceCountA.Length; i++){
      if( faceCountA[i] == 2) faceA= A[faceCountA[i]].Value;
    }
    for(int i=0; i< faceCountB.Length; i++){
      if( faceCountB[i] == 2) faceB= B[faceCountA[i]].Value;
    }
    
    //Logic to find if A and B are both three of a Kind
    if(faceA > faceB){
      return A;
    } else if(faceB > faceA){
      return B;
    }
    //if the face cards are same then we check 4th and 5th card to find the winner 
    else{
      int[] remA =new int[0];
      for(int i=0; i<NumberOfCards; i++){
        if(A[i].Value!= faceA)remA.Append(A[i].Value);
      }
      Array.Sort(remA); 
      int[] remB = new int[0]; 
      for(int i=0; i<NumberOfCards; i++){
        if(B[i].Value!= faceB)remB.Append(B[i].Value);
      }
      Array.Sort(remB);

      for(int i= remA.Length-1; i>=0; i--){
        if(remA[i] == remB[i]){
          continue ;
        } else if(remA[i] > remB[i]){
          winner = A;
          return A;
        } else {
          winner = B;
          return B;
        }
      }
    }
    return winner;
  }


  //Helper function to get the array of cards of a particular suit
  static int[] cardsOfSameSuit(Card[] cards, String suit){
    int[] res = new int[cards.Length];
    for(int i=0; i<cards.Length; i++){
      if(cards[i].Suit == suit)res[i] = cards[i].Value;
    }
    return res;
  }  

  //Case 4. Find the highest card in the set of the Player.
  static Card[] highCardTie(Card[] A, Card[] B){
    Card[] winner = A;
    int[] cards_of_A = new int[5];
    int[] cards_of_B = new int[5];
    
    for(int i=0; i<5; i++){
      cards_of_A[i]= A[i].Value;
      cards_of_B[i]= B[i].Value;
    }

    // Sorting players cards to get highest face value card
    Array.Sort(cards_of_A); Array.Reverse(cards_of_B);
    Array.Sort(cards_of_A);Array.Reverse(cards_of_B);
    
    for(int i=0; i<5; i++){
      if(cards_of_A[i] == cards_of_B[i]){
        continue;
      }else if(cards_of_A[i] > cards_of_B[i]){
        return A;
      } else{
        return B;
      }
    }
    return winner;
  }
  static int findHighCard(Card[] cards)
  {
    int highest = cards[0].Value;
    for (int i = 0; i < 5; i++){
      highest= Math.Max(highest, cards[i].Value);
    }
    return highest;
  }

  static bool flushCheck(Card[] Joe, Card[] Jen, Card[] Bob, Dictionary<Card[], String> PlayerHash){
      if(isFlush(Joe) || isFlush(Jen) || isFlush(Bob)){
        if(isFlush(Joe) && isFlush(Jen) && isFlush(Bob)){
          Console.WriteLine("All three are Flush ");
          Card[] res = flushTie(Joe, Jen);
          res = flushTie(res, Bob);
          Console.WriteLine(PlayerHash[res]+ " Won!");
        } 
        else if(isFlush(Joe) && isFlush(Jen)){
          Console.WriteLine("Flush TIE ");
          Card[] res = flushTie(Joe, Jen);
          Console.WriteLine(PlayerHash[res]+ " Won!");
        }
        else if(isFlush(Jen) && isFlush(Bob)){
          Console.WriteLine("Flush TIE ");
          Card[] res = flushTie(Jen, Bob);
          Console.WriteLine(PlayerHash[res]+ " Won!");
        }
        else if(isFlush(Joe) && isFlush(Bob)){
          Console.WriteLine("Flush TIE ");
          Card[] res = flushTie(Joe, Bob);
          Console.WriteLine(PlayerHash[res]+ " Won!");
        }
        else if(isFlush(Bob)){
          Console.WriteLine(PlayerHash[Bob]+ " Won!");
        }
        else if(isFlush(Joe)){
          Console.WriteLine(PlayerHash[Joe]+ " Won!");
        }
        else if(isFlush(Jen)){
          Console.WriteLine(PlayerHash[Jen]+ " Won!");
        }
        return true;
      }
      return false;
  }

  static bool threeKindCheck(Card[] Joe, Card[] Jen, Card[] Bob, Dictionary<Card[], String> PlayerHash){
      if(isThreeOfaKind(Joe) || isThreeOfaKind(Jen) || isThreeOfaKind(Bob)){
        if(isThreeOfaKind(Joe) && isThreeOfaKind(Jen) && isThreeOfaKind(Bob)){
          Console.WriteLine("All three of a Kind Tie");
          Card[] res = threeOfaKind_Tie(Joe, Jen);
          res = threeOfaKind_Tie(res, Bob);
          Console.WriteLine(PlayerHash[res]+ " Won!");
        } 
        else if(isThreeOfaKind(Joe) && isThreeOfaKind(Jen)){
          Console.WriteLine("Three of a Kind TIE");
          Card[] res = threeOfaKind_Tie(Joe, Jen);
          Console.WriteLine(PlayerHash[res]+ " Won!");
        }
        else if(isThreeOfaKind(Jen) && isThreeOfaKind(Bob)){
          Console.WriteLine("Three of a Kind TIE");
          Card[] res = threeOfaKind_Tie(Jen, Bob);
          Console.WriteLine(PlayerHash[res]+ " Won!");
        }
        else if(isThreeOfaKind(Joe) && isThreeOfaKind(Bob)){
          Console.WriteLine("Three of a Kind TIE ");
          Card[] res = threeOfaKind_Tie(Joe, Bob);
          Console.WriteLine(PlayerHash[res]+ " Won!");
        }
        else if(isThreeOfaKind(Bob)){
          Console.WriteLine(PlayerHash[Bob]+ " Won!");
        }
        else if(isThreeOfaKind(Joe)){
          Console.WriteLine(PlayerHash[Joe]+ " Won!");
        }
        else if(isThreeOfaKind(Jen)){
          Console.WriteLine(PlayerHash[Jen]+ " Won!");
        }
        return true;
      }
      return false;
  }

  static bool onePairCheck(Card[] Joe, Card[] Jen, Card[] Bob, Dictionary<Card[], String> PlayerHash){
      if(isOnePair(Joe) || isOnePair(Jen) || isOnePair(Bob)){
        if(isOnePair(Joe) && isOnePair(Jen) && isOnePair(Bob)){
          Console.WriteLine("All One Pair Tie");
          Card[] res = onePair_Tie(Joe, Jen);
          res = onePair_Tie(res, Bob);
          Console.WriteLine(PlayerHash[res]+ " Won!");
        } 
        else if(isOnePair(Joe) && isOnePair(Jen)){
          Console.WriteLine("One Pair TIE");
          Card[] res = onePair_Tie(Joe, Jen);
          Console.WriteLine(PlayerHash[res]+ " Won!");
        }
        else if(isOnePair(Jen) && isOnePair(Bob)){
          Console.WriteLine("One Pair TIE");
          Card[] res = onePair_Tie(Jen, Bob);
          Console.WriteLine(PlayerHash[res]+ " Won!");
        }
        else if(isOnePair(Joe) && isOnePair(Bob)){
          Console.WriteLine("One Pair TIE ");
          Card[] res = onePair_Tie(Joe, Bob);
          Console.WriteLine(PlayerHash[res]+ " Won!");
        }
        else if(isOnePair(Bob)){
          Console.WriteLine(PlayerHash[Bob]+ " Won!");
        }
        else if(isOnePair(Joe)){
          Console.WriteLine(PlayerHash[Joe]+ " Won!");
        }
        else if(isOnePair(Jen)){
          Console.WriteLine(PlayerHash[Jen]+ " Won!");
        }
        return true;
      }
      return false;
  }



  static bool highCardCheck(Card[] Joe, Card[] Jen, Card[] Bob, Dictionary<Card[], String> PlayerHash){      
      if((findHighCard(Joe) == findHighCard(Jen)) || (findHighCard(Jen) == findHighCard(Bob)) || (findHighCard(Joe) == findHighCard(Bob))){
        if((findHighCard(Joe) == findHighCard(Jen)) && (findHighCard(Jen) == findHighCard(Bob)) && (findHighCard(Joe) == findHighCard(Bob))){
          Console.WriteLine("All Highest Card TIE");
          Card[] res = highCardTie(Joe, Jen);
          res = highCardTie(res, Bob);
          Console.WriteLine(PlayerHash[res]+ " Won!");
        } 
        else if(findHighCard(Joe) == findHighCard(Jen)){
          Console.WriteLine("HighCard TIE");
          Card[] res = highCardTie(Joe, Jen);
          Console.WriteLine(PlayerHash[res]+ " Won!");
        }
        else if(findHighCard(Jen) == findHighCard(Bob)){
          Console.WriteLine("HighCard TIE");
          Card[] res = highCardTie(Joe, Bob);
          Console.WriteLine(PlayerHash[res]+ " Won!");
        }
        else if(findHighCard(Joe) == findHighCard(Bob)){
          Console.WriteLine("HighCard TIE ");
          Card[] res = highCardTie(Joe, Bob);
          Console.WriteLine(PlayerHash[res]+ " Won!");
        }
        else {
         int JoeHC = findHighCard(Joe), JenHC = findHighCard(Jen), BobHC = findHighCard(Bob);
          if(JoeHC > JenHC && JoeHC > BobHC){
            Console.WriteLine(PlayerHash[Joe]+ " Won!");
            return true;
          }
          else if(JenHC > JoeHC && JenHC > BobHC){
            Console.WriteLine(PlayerHash[Jen]+ " Won!");
            return true;
          }
          else{
            Console.WriteLine(PlayerHash[Bob]+ " Won!");
            return true;
          }
        }
        return true;
      }
      return false;
  }
}