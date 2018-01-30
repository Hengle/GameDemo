using UnityEngine;

namespace Goap
{
    public class GoapAgent : MonoBehaviour
    {
        protected GoapPlanManager goapPlanManager;
        protected GoapActionManager goapActionManager;
        protected GoapStateManager goapStateManager;
        protected StateMachine stateMachine;
        protected AnimationManager animationManager;
        protected SkillManager skillManager;

        private GoapAgent target;
        private float hp = 0;
        private int npcId;
        private NpcData npcData = null;

        // Use this for initialization
        protected virtual void Start()
        {
            Init();
        }

        // Update is called once per frame
        protected virtual void Update()
        {
            Controller();
        }

        public virtual void Init()
        {
            goapPlanManager = new GoapPlanManager( this);
            goapActionManager = new GoapActionManager(this);

            goapStateManager = new GoapStateManager(this);
            stateMachine = new StateMachine(this);
            animationManager = new AnimationManager(transform);

            skillManager = new SkillManager(this);

            if (HpControllerPanel.instance != null)
            {
                HpControllerPanel.instance.GetHp(this);
            }
        }

        protected virtual void Controller()
        {
            if (!IsAlive())
            {
                UnitManager.RemoveMonster(this);
                GameObject.Destroy(gameObject);
                return;
            }

            goapActionManager.OnFrame();

            goapStateManager.OnFrame();

            stateMachine.OnFrame();
            skillManager.OnFrame();
        }

        public NpcData NpcData { get { return npcData; } }

        public int NpcID {
            get { return npcId; }
            set {
                npcId = value;
                npcData = TableTool.GetTableDataRow<NpcData>(TableType.Npc, value);
                hp = npcData.hp;
            }
        }

        public Camp Camp { get; set; }

        public GoapAgent Target
        {
            get { return target; }
            set { target = value; }
        }

        public bool HasTarget { get { return target != null; } }

        /// <summary>
        /// 记录攻击实使用的技能
        /// </summary>
        public Skill AttackUseSkill { get; set; }

        public Skill UseableSkill()
        {
            if (skillManager == null)
            {
                return null;
            }
            return skillManager.GetUseableSkill();
        }

        public bool InAttackRange()
        {
            if (target == null)
            {
                return false;
            }

            float distance = Vector3.Distance(target.transform.position, transform.position);

            Skill skill = UseableSkill();
            if (skill == null)
            {
                return true;
            }

            return distance <= skill.Range();
        }

        public bool IsAlive()
        {
            return hp > 0;
        }

        public float Hp { get { return hp; } }

        public void Damage(float value)
        {
            hp -= value;
        }

        public void LookTarget()
        {
            transform.LookAt(target.transform);
        }

        public AnimationManager AnimationManager { get { return animationManager; } }

        /// <summary>
        /// 行为管理器
        /// </summary>
        public GoapPlanManager GoapPlanManager { get { return goapPlanManager; } }

        /// <summary>
        /// 行为管理器
        /// </summary>
        public GoapActionManager GoapActionManager { get { return goapActionManager; } }

        /// <summary>
        /// 目标、状态 管理器
        /// </summary>
        public GoapStateManager GoapStateManager { get { return goapStateManager; } }

        /// <summary>
        /// 有限状态机
        /// </summary>
        public StateMachine StateMachine { get { return stateMachine; } }
    }
}