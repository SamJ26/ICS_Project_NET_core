using FilmManagment.BL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FilmManagment.GUI.Messages
{
    // TODO: not sure if it works with ModelBase

    public class NewMessage<TwrappedModel>: Message<TwrappedModel> where TwrappedModel : ModelBase
    {
    }

    public class UpdateMessage<TwrappedModel> : Message<TwrappedModel> where TwrappedModel : ModelBase
    {
    }

    public class DeleteMessage<TwrappedModel> : Message<TwrappedModel> where TwrappedModel : ModelBase
    {
    }

    public class SelectMessage<TwrappedModel> : Message<TwrappedModel> where TwrappedModel : ModelBase
    {
    }
}
