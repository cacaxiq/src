namespace Base.Domain.Handler
{
    public class ProspectHandler { }
    //    : 
    //    IHandler<CreateProspectCommand>,
    //    IHandler<EditProspectCommand>
    //{
    //    IProspectRepository prospectRepository;

    //    public ProspectHandler(
    //        IProspectRepository _prospectRepository)
    //    {
    //        prospectRepository = _prospectRepository;
    //    }

    //    public ICommandResult Handle(CreateProspectCommand command)
    //    {
    //        command.FillEntities();
    //        if (command.Invalid)
    //            return new CommanResult(false, command.Error());

    //        prospectRepository.Add(command.Prospect);

    //        return new CommanResult(true, "Informações de usuário inseridas com sucesso.");
    //    }

    //    public ICommandResult Handle(EditProspectCommand command)
    //    {
    //        command.FillEntities();
    //        if (command.Invalid)
    //            return new CommanResult(false, command.Error());
                        
    //        prospectRepository.Update(command.Prospect);

    //        return new CommanResult(true, "Informações de usuário alteradas com sucesso.");
    //    }
    //}
}
