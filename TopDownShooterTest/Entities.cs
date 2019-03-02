using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TopDownShooterTest
{
    class PlayerShip
    {
        private Texture2D ShipTexture { get; set; }
        public int MaxHP { get; set; }
        public int MaxSE { get; set; }
        public int ShieldRegenRate { get; set; }
        public Weapon ShipWeapon { get; set; }
        public int RateOfFire { get; set; }
        public int ShipSpeed { get; set; }

        private int CurrentShotCooldownTimer = 0;
        public Vector2 ShipCoords = new Vector2(0, 0);

        public PlayerShip(Texture2D shipTexture, int maxHealth, int maxShield, int shieldRegenRate, int speed, Weapon givenWeapon)
        {
            ShipTexture = shipTexture;
            ShipWeapon = givenWeapon;
            MaxHP = MaxHP;
            MaxSE = maxShield;
            ShieldRegenRate = shieldRegenRate;
            ShipSpeed = speed;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(ShipTexture, new Vector2(ShipCoords.X - (ShipTexture.Width / 2), ShipCoords.Y - (ShipTexture.Height / 2)), Color.White);
            spriteBatch.End();
        }

        public int GiveDiagonalSpeed()
        {
            int DSpeed = (int)(Math.Sqrt(2) * (ShipSpeed / 2));
            return DSpeed;
        }

        public void ModifyShipPosition(int axis, int amount)
        {
            if (axis == 0)
            {
                int NewX = 0;
                if (ShipCoords.X + amount < 0)
                {
                    NewX = 0;
                }
                else if (ShipCoords.X + amount > 480)
                {
                    NewX = 480;
                }
                else
                {
                    NewX = (int)ShipCoords.X + amount;
                }

                ShipCoords = new Vector2(NewX, ShipCoords.Y);
            }
            else
            {
                int NewY = 0;
                if (ShipCoords.Y + amount < 0)
                {
                    NewY = 0;
                }
                else if (ShipCoords.Y + amount > 640)
                {
                    NewY = 640;
                }
                else
                {
                    NewY = (int)ShipCoords.Y + amount;
                }

                ShipCoords = new Vector2(ShipCoords.X, NewY);
            }
        }
    }

    class Projectile
    {
        private Texture2D ProjectileTexture { get; set; }
        public int ProjectileDamage { get; set; }

        public Projectile(Texture2D projectileTexture, int damage)
        {
            ProjectileTexture = projectileTexture;
            ProjectileDamage = damage;
        }
    }

    class Weapon
    {
        public string IdentifierName { get; set; }
        public string WeaponName { get; set; }
        public Projectile WeaponProjectile { get; set; }
        public int RateDelay { get; set; }
        public int ShotCount { get; set; }
        public int SpreadType { get; set; }
        public float SpreadAngle { get; set; }

        private int CurrentDelay = 0;

        public Weapon(string idName, string name, Projectile shotProjectile, int rof, int amount, int spreadType, float spreadAngle)
        {

        }
    }
}
