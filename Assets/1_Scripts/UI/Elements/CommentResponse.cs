using JetBrains.Annotations;

namespace UI.Elements
{
    public class CommentResponse : CommentBase
    {
        public void Initialize([NotNull] ScriptableObjects.CommentResponse comment)
        {
            characterPicture.sprite = comment.character.profilePicture;
            characterName.text = comment.character.GetNameString();
            text.text = LocalizationHelper.Get(comment.text);
        }
    }
}