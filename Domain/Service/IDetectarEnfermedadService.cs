namespace Domain.Entity
{
    public interface IDetectarEnfermedadService
    {
        DetectarEnfermedadResponse CalcularProbabilidad(DetectarEnfermedadRequest request);

    }
}