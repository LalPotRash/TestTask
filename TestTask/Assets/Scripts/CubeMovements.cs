using Cinemachine;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CubeMovements : MonoBehaviour
{
    [SerializeField] private float _spawnTime;
    [SerializeField] private float _cubeSpeed;
    [SerializeField] private float _cubeDistance;

    private Cube _cube;
    private Ground _ground;
    private GameObject _cubeGO;
    private CinemachineVirtualCamera _cinemachineCamera;

    private void Start()
    {
        _cube = new Cube();
        _ground = new Ground();

        _cubeGO = Instantiate(_cube.cubePrefab);

        _cinemachineCamera = Camera.main.GetComponent<CinemachineVirtualCamera>();
        _cinemachineCamera.Follow = _cubeGO.transform;

        int groundCount = 5;

        for (int i = 0; i < groundCount; i++)
            Instantiate(_ground.groundPrefab, new Vector3(0, -2, i * 25), Quaternion.identity);
    }

    private void Update()
    {
        if (!_cubeGO.IsDestroyed() && _cubeDistance > 0)
        {
            _cubeGO.transform.position = Vector3.MoveTowards(_cubeGO.transform.position, new Vector3(0, -1, _cubeDistance), _cubeSpeed * Time.deltaTime);

            if (_cubeGO.transform.position.z >= _cubeDistance)
                StartCoroutine(Spawner());
        }
    }

    private IEnumerator Spawner()
    {
        _cinemachineCamera.Follow = null;
        Destroy(_cubeGO);

        yield return new WaitForSeconds(_spawnTime);

        _cubeGO = Instantiate(_cube.cubePrefab);
        _cinemachineCamera.Follow = _cubeGO.transform;
    }

    public void SpawnTimeValueChanged()
    {
        _spawnTime = GameObject.Find("SpawnTimeSlider").GetComponent<Slider>().value;
        GameObject.Find("SpawnTimeValue").GetComponent<Text>().text = _spawnTime.ToString();
    }

    public void SpeedValueChanged()
    {
        _cubeSpeed = GameObject.Find("SpeedSlider").GetComponent<Slider>().value;
        GameObject.Find("SpeedValue").GetComponent<Text>().text = _cubeSpeed.ToString();
    }

    public void DistanceValueChanged()
    {
        _cubeDistance = GameObject.Find("DistanceSlider").GetComponent<Slider>().value;
        GameObject.Find("DistanceValue").GetComponent<Text>().text = _cubeDistance.ToString();
    }
}
