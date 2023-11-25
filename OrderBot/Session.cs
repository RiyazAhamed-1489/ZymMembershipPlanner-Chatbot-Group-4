using System;
using System.Numerics;

namespace OrderBot
{
    public class Session
    {
        private enum State
        {
            WELCOMING, NAME, GENDER,AGE, EMAIL_ID, CONTACT_NO,MEMBERSHIP_PLAN, MEMBERSHIP_DETAILS,PLANS
        }

        private State nCur = State.WELCOMING;
        private Order oOrder;

        public Session(string sPhone)
        {
            this.oOrder = new Order();
           // this.oOrder.Phone = sPhone;
        }

        public List<String> OnMessage(String sInMessage)
        {
            List<String> aMessages = new List<string>();
            switch (this.nCur)
            {
                case State.WELCOMING:
                   
                    aMessages.Add("Hello! Welcome to FitForLess");

                    aMessages.Add("Can I have some information about you");
                    
                    this.nCur = State.NAME;
                    break;
                case State.NAME:
                    aMessages.Add("Please provide your fullname");
                      this.nCur = State.GENDER;
                      break;

                case State.GENDER:

                    aMessages.Add("Please provide your Gender");
                    this.nCur = State.AGE;
                    break;
                case State.AGE:

                    aMessages.Add("Please provide your Age");
                    this.nCur = State.EMAIL_ID;
                    break;
                case State.EMAIL_ID:

                    aMessages.Add("Please provide your Email id");
                    this.nCur = State.CONTACT_NO;
                    break;
                case State.CONTACT_NO:

                    aMessages.Add("Please provide your Contact no");
                    this.nCur = State.MEMBERSHIP_PLAN;
                    break;

                case State.MEMBERSHIP_PLAN:
                    aMessages.Add("Thank you for providing your personal information");
                  
                    aMessages.Add("We offer various membership types to suit your needs. "
                         + "You can choose from [Gold], [Plantinum], and [Silver].");
                    aMessages.Add("Would you like me to explain the differences between these plans ? Yes/No ");
                    this.nCur = State.MEMBERSHIP_DETAILS;
                    
                    break;
                case State.MEMBERSHIP_DETAILS:
                    
                    aMessages.Add("\"Sure! The Silver plan costs $30/month, the Plantinum plan is $50/month, \"\r\n + \"and the Gold plan is $60/month.");
                    aMessages.Add("What membership plan would you like to enroll (silver/plantinum/gold) ");
                   
                    
                    this.nCur = State.PLANS;
                    break;
                case State.PLANS:
                    this.oOrder.Plans = sInMessage;
                    //this.oOrder.Save();
                    aMessages.Add("Thanks for enrolling to "  + this.oOrder.Plans);

                    //this.oOrder.Save();
                   // aMessages.Add("Kindly proceed with the payment we will integrate paypal payment later");
                    break;


            }
            aMessages.ForEach(delegate (String sMessage)
            {
                System.Diagnostics.Debug.WriteLine(sMessage);
            });
            return aMessages;
        }

    }
}
