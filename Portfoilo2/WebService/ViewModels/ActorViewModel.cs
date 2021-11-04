namespace WebService
{
    public class ActorViewModel
    {
        private ActorViewModel CreateActorViewModel(Actor actor) 
        {
            var model = _mapper.Map<ActorViewModel>(actor);
            model.Url = GetUrl(actor);
            return model;
        }
    }
}