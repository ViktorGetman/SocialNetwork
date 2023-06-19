using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.PLL.Views
{
    public class AddingToFriendsView
    {
        
        FriendService friendService;
        public AddingToFriendsView(FriendService friendService)
        {
            this.friendService = friendService;
           
        }

        public void Show(User user)
        {
            var addFriendData = new AddFriendData();

            Console.Write("Введите почтовый адрес пользователя: ");
            addFriendData.RecipientEmail = Console.ReadLine();

            addFriendData.UserId = user.Id;

            try
            {
                friendService.AddFrend(addFriendData);

                SuccessMessage.Show("Друг успешно добавлен!");

             
            }

            catch (UserNotFoundException)
            {
                AlertMessage.Show("Пользователь не найден!");
            }
                      
            catch (Exception)
            {
                AlertMessage.Show("Произошла ошибка при добавлени в друзья!");
            }

        }
    }
}