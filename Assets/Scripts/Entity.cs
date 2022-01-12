namespace Home
{
    public class Entity
    {
        public string id { get; protected set; }
        public float healthLimit { get; set; }
        public float selfDamage { get; set; }
        public string name { get; set; }
        private float _health;

        public delegate void DeathDelegate(string id);
        public event DeathDelegate Death;

        public float health
        {
            get { return _health; }
            set
            {
                if (value <= healthLimit)
                    _health = value;
            }
        }

        public Entity() { }

        public Entity(float healthLimit, float health, float selfDamage, string name)
        {
            this.id = Helper.GenerateGUID();
            this.healthLimit = healthLimit;
            this.health = health;
            this.selfDamage = selfDamage;
            this.name = name;
        }

        public void Heal(float healingPoints)
        {
            this.health += healingPoints;
        }

        public void TakeDamage(float damagePoints)
        {
            this.health -= damagePoints;
            if (this.health <= 0)
                Death?.Invoke(this.id);
        }
    }
}
