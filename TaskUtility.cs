using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace xOrfe.Utilities
{
    public class TaskUtility : MonoBehaviour
    {
        public TaskInfo[] TaskInfos;
        
        public TaskInfo BaseTaskInfo;
        public TaskInfo CurrentTaskInfo;
        
        private IEnumerator coroutine;

        private void FixedUpdate()
        {
            if (CurrentTaskInfo.ExecuteEveryFrame) ExecuteTask();
        }

        public void ExecuteTask()
        {
            CurrentTaskInfo.ExecuteMethod?.Invoke();
        }
        public void SetTask(TaskInfo taskInfo,bool isResetCall)
        {
            if (taskInfo.IsBaseTask) BaseTaskInfo = taskInfo;
            if (!CurrentTaskInfo.AllowSetTaskMethod && !isResetCall) return;
            if(coroutine != null)StopCoroutine(coroutine);
            
            CurrentTaskInfo = taskInfo;
            if (CurrentTaskInfo.HaveDuration)
            {
                coroutine = DelayedTaskResetCall(CurrentTaskInfo.Duration);
                StartCoroutine(coroutine);
            }
            else
            {
                coroutine = null;
            }
            if (!CurrentTaskInfo.ExecuteEveryFrame) ExecuteTask();
        }
        
        private IEnumerator DelayedTaskResetCall(float wait)
        {
            yield return new WaitForSeconds(wait);
            SetTask(BaseTaskInfo,true);
        }
    }

    [System.Serializable]
    public class TaskInfo
    {
        public string Name;
        public UnityEvent ExecuteMethod;
        public bool HaveDuration;
        public float Duration;
        public bool AllowSetTaskMethod;
        public bool ExecuteEveryFrame;
        public bool IsBaseTask;
    }
    
    
}
