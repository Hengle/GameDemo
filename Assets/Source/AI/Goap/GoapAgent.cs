using UnityEngine;

namespace Goap
{
    public class GoapAgent : MonoBehaviour
    {
        private GoapPlanManager goapPlanManager;
        private GoapActionManager goapActionManager;
        protected GoapStateManager goapStateManager;

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

        protected virtual void Init()
        {
            goapPlanManager = new GoapPlanManager( this);
            goapActionManager = new GoapActionManager(this);
        }

        protected virtual void Controller()
        {
            goapActionManager.OnFrame();
            goapStateManager.OnFrame();
        }

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
    }
}