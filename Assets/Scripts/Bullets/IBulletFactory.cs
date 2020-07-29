namespace MVCExample
{
    public interface IBulletFactory
    {
        IBullet CreateBullet(BulletsData data, BulletsType type);
    }
}