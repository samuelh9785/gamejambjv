using System.Collections;
using UnityEngine;

namespace Com.Four.Common.Shakes
{
    public class Shake
    {
        private MonoBehaviour caster;
        private Transform target;
        private ShakeSetting setting;
        private Coroutine coroutine;
        private bool isLocal;
        private Vector2 startPosition;

        /// <summary>
        /// Short for "new Shake(caster, camera.main.transform, setting, isLocal).Play()"
        /// </summary>
        /// <param name="caster">The monobehaviour responsible for holding the coroutine execution</param>
        /// <param name="setting">The associated shake setting</param>
        /// <param name="isLocal">Is the transformation applied in local space ?</param>
        /// <returns></returns>
        public static Shake ScreenShake(MonoBehaviour caster, ShakeSetting setting, bool isLocal)
        {
            return new Shake(caster, Camera.main.transform, setting, isLocal).Play();
        }
        /// <summary>
        /// Create a new shake object
        /// </summary>
        /// <param name="caster">The monobehaviour responsible for holding the coroutine execution</param>
        /// <param name="target">The target of the shake</param>
        /// <param name="setting">The associated shake setting</param>
        /// <param name="isLocal">Is the transformation applied in local space ?</param>
        public Shake(MonoBehaviour caster, Transform target, ShakeSetting setting, bool isLocal = false)
        {
            this.caster = caster;
            this.target = target;
            this.setting = setting;
            this.isLocal = isLocal;
        }
        /// <summary>
        /// Create a new shake object
        /// </summary>
        /// <param name="caster">The monobehaviour responsible for holding the coroutine execution and target of the shake</param>
        /// <param name="setting">The associated shake setting</param>
        /// <param name="isLocal">Is the transformation applied in local space ?</param>
        public Shake(MonoBehaviour caster, ShakeSetting setting, bool isLocal = false) : this(caster, caster.transform, setting, isLocal) { }

        /// <summary>
        /// Stop this shake execution
        /// </summary>
        /// <returns></returns>
        public Shake Stop()
        {
            if (!isValid)
                return this;

            if (coroutine != null)
                caster.StopCoroutine(coroutine);

            coroutine = null;
            return this;
        }
        /// <summary>
        /// Start this shake execution (reset if is already playing)
        /// </summary>
        /// <returns></returns>
        public Shake Play()
        {
            if (!isValid)
                return this;

            if (coroutine != null)
                caster.StopCoroutine(coroutine);

            coroutine = caster.StartCoroutine(PlayShake());

            return this;
        }
        /// <summary>
        /// Reset the object to its initial position state
        /// </summary>
        /// <returns>return this shake</returns>
        public Shake Reset()
        {
            if (isLocal)
                target.localPosition = startPosition;
            else
                target.position = startPosition;

            return this;
        }

        private IEnumerator PlayShake()
        {
            float ratio;
            float timer = 0;

            startPosition = isLocal ? target.localPosition : target.position;
            Vector2 driver = Random.insideUnitCircle;

            while(timer < setting.Duration)
            {
                ratio = timer / setting.Duration;

                if (isLocal)
                    target.localPosition = startPosition + Noise(driver, setting.Bidirectionnal) * (setting.Magnitude * setting.CurvePosition(ratio));
                else
                    target.position = startPosition + Noise(driver, setting.Bidirectionnal) * (setting.Magnitude * setting.CurvePosition(ratio));

                driver += Vector2.one * (setting.Frequency * Time.deltaTime);
                timer += Time.deltaTime;

                yield return new WaitForEndOfFrame();
            }

            if(isLocal)
                target.transform.localPosition = startPosition;
            else
                target.transform.position = startPosition;

            coroutine = null;
        }

        private static Vector2 Noise(Vector2 driver, bool bidirectionnal)
        {
            if (bidirectionnal)
            {
                return new Vector2(Mathf.PerlinNoise(driver.x, driver.y), Mathf.PerlinNoise(driver.y, driver.x)) * 2 - Vector2.one;
            }
            return new Vector2(Mathf.PerlinNoise(driver.x, driver.y), Mathf.PerlinNoise(driver.y, driver.x));
        }

        /// <summary>
        /// Returns if this shake has settings, a target & a caster
        /// </summary>
        private bool isValid => setting && target && caster;
    }
}
