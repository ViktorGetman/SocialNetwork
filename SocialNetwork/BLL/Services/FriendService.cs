using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;


namespace SocialNetwork.BLL.Services
{
    public class FriendService
    {

        IUserRepository userRepository;
        IFriendRepository friendRepository;
        public FriendService()
        {
            userRepository = new UserRepository();
            friendRepository = new FriendRepository();
        }


        public void AddFrend(AddFriendData addFriendData)
        {
            var findUserEntity = this.userRepository.FindByEmail(addFriendData.RecipientEmail);
            if (findUserEntity is null) throw new UserNotFoundException();

            var friendEntity = new FriendEntity()
            {
                friend_id = findUserEntity.id,
                user_id = addFriendData.UserId,

            };

            if (this.friendRepository.Create(friendEntity) == 0)
                throw new Exception();
        }
    }
}
