using UnityEngine;

public class controles : MonoBehaviour {
    
    //public ManagerSonido manager;

    public int vidas = 3;

    Rect p1Zone;
    Rect p2Zone;

    Vector3 posOriginalMovimiento = Vector3.zero;
    Vector3 posOriginalDisparo = Vector3.zero;

    //public GameObject jugador;
    public float vel = 2f;
    public float limite = 0.5f;

	public float tiempoDisparo = 0.5f;
	float tiempoDisparoUsado = 0f;
	bool balaKetchup = true;
	public float potenciaDisparo = 50f;

	public GameObject balak;
	public Transform posk1;
	public Transform posk2;
	public GameObject brazoK;

	public GameObject balam;
	public Transform posm1;
	public Transform posm2;
	public GameObject brazoM;

    int moviendo,disparando = -1;
    bool disparar = false;

    Vector3 mov = Vector3.zero;
    Vector3 dis = Vector3.zero;

    public float municionK = 25;
    //Para mostrar la municion falta por hacer
    //public Image imagenK;
    public float municionM = 25;

    public UnityEngine.UI.Image porcentajeK;
    public UnityEngine.UI.Image porcentajeM;

    public GameObject cuerpo;
    public Texture[] texturasCuerpo;
    public GameObject patas;
    public Texture[] texturasPatas;

    public void Start()
    {
        p1Zone = new Rect(0, 0, Screen.width * 0.5f, Screen.height);
        p2Zone = new Rect(Screen.width * 0.5f, 0, Screen.width * 0.5f, Screen.height);
    }

    public void Update()
    {
		tiempoDisparoUsado += Time.deltaTime;

        // Handle native touch events
	    foreach (Touch touch in Input.touches) {
            MirarZona(touch.fingerId, touch.position, touch.phase);
	    }

        // Simulate touch events from mouse events
        if (Input.touchCount == 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                MirarZona(10, Camera.main.ScreenToWorldPoint(Camera.main.WorldToScreenPoint(Input.mousePosition)), TouchPhase.Began);
            }
            if (Input.GetMouseButton(0))
            {
                MirarZona(10, Camera.main.ScreenToWorldPoint(Camera.main.WorldToScreenPoint(Input.mousePosition)), TouchPhase.Moved);
            }
            if (Input.GetMouseButtonUp(0))
            {
                MirarZona(10, Camera.main.ScreenToWorldPoint(Camera.main.WorldToScreenPoint(Input.mousePosition)), TouchPhase.Ended);
            }
        }

        porcentajeK.fillAmount = municionK/25;
        porcentajeM.fillAmount = municionM/25;
    }

    public void FixedUpdate(){
        if (moviendo != -1)
            MoverJugador();

        if (disparar && disparando != -1)
            Disparar();
    }

    private void MirarZona(int touchFingerId, Vector3 touchPosition, TouchPhase touchPhase)
    {
        if (p1Zone.Contains(touchPosition) || moviendo == touchFingerId)
        {
            switch (touchPhase){
                case TouchPhase.Began:
                    posOriginalMovimiento = touchPosition;
                    moviendo = touchFingerId;
				    MirarMovimiento (touchPosition);
                    break;

                case TouchPhase.Moved:
                case TouchPhase.Stationary:
                    if (moviendo == touchFingerId)
				        MirarMovimiento (touchPosition);
                    break;

                case TouchPhase.Ended:
                    moviendo = -1;
                    cuerpo.GetComponent<Renderer>().material.mainTexture = texturasCuerpo[0];
                    patas.GetComponent<Renderer>().material.mainTexture = texturasPatas[0];
                    break;
            }
        }
        else if(p2Zone.Contains(touchPosition) || disparando == touchFingerId) // implied
        {
            switch (touchPhase){
                case TouchPhase.Began:
                    posOriginalDisparo = touchPosition;
                    disparando = touchFingerId;
				    MirarDisparo (touchPosition);
                    break;

                case TouchPhase.Moved:
                case TouchPhase.Stationary:
                    if (disparando == touchFingerId)
				        MirarDisparo (touchPosition);
                    break;

                case TouchPhase.Ended:
                    disparando = -1;
                    posOriginalDisparo = Vector3.zero;
                    break;
            }
        }
    }

    private void MirarMovimiento(Vector3 touchPosition)
    {
        Vector3 direccionNormalizada = Vector3.Normalize(touchPosition - posOriginalMovimiento);
        Vector3 direccion = touchPosition - posOriginalMovimiento;

        if (direccion.magnitude > limite)
        {
            mov.x = direccionNormalizada.x;
            mov.z = direccionNormalizada.y;
        }else{
            mov = Vector3.zero;
        }
    }

	private void MirarDisparo(Vector3 touchPosition)
	{
		Vector3 direccionNormalizada = Vector3.Normalize(touchPosition - posOriginalDisparo);
		Vector3 direccion = touchPosition - posOriginalDisparo;

		if (direccion.magnitude > limite) {
			dis.x = direccionNormalizada.x;
			dis.z = direccionNormalizada.y;

			brazoK.transform.rotation = Quaternion.LookRotation (-dis);
			brazoM.transform.rotation = Quaternion.LookRotation (-dis);

            disparar = true;
		}else{
            disparar = false;
        }
	}

    private void MoverJugador()
    {
        if (mov.x > 0.25f){
            cuerpo.GetComponent<Renderer>().material.mainTexture = texturasCuerpo[2];
            patas.GetComponent<Renderer>().material.mainTexture = texturasPatas[2];
        }
        if (mov.x < -0.25f){
            cuerpo.GetComponent<Renderer>().material.mainTexture = texturasCuerpo[1];
            patas.GetComponent<Renderer>().material.mainTexture = texturasPatas[1];
        }

        if (mov.x <= 0.25f && mov.x >= -0.25f){
            cuerpo.GetComponent<Renderer>().material.mainTexture = texturasCuerpo[0];
            patas.GetComponent<Renderer>().material.mainTexture = texturasPatas[0];
        }
        
        gameObject.transform.Translate(mov);
    }

	private void Disparar(){

        if (tiempoDisparoUsado >= tiempoDisparo) {

            tiempoDisparoUsado = 0f;

            if (balaKetchup) {
                if (brazoK.transform.rotation.eulerAngles.y < 90f && brazoK.transform.rotation.eulerAngles.y >= 0f
                || brazoK.transform.rotation.eulerAngles.y > 270f && brazoK.transform.rotation.eulerAngles.y <= 360f) {
                    DispararBala (brazoK, balak, posk1);
                }

                if (brazoK.transform.rotation.eulerAngles.y >= 90f && brazoK.transform.rotation.eulerAngles.y <= 270f) {
                    DispararBala (brazoK, balak, posk2);
                }
            } else {

                if (brazoM.transform.rotation.eulerAngles.y < 90f && brazoM.transform.rotation.eulerAngles.y >= 0f
                || brazoM.transform.rotation.eulerAngles.y > 270f && brazoM.transform.rotation.eulerAngles.y <= 360f) {
                    DispararBala (brazoM, balam, posm1);
                }

                if (brazoM.transform.rotation.eulerAngles.y >= 90f && brazoM.transform.rotation.eulerAngles.y <= 270f) {
                    DispararBala (brazoM, balam, posm2);
                }
            }

            balaKetchup = !balaKetchup;

            //Debug.Log("K "+municionK+" y M "+municionM);
        }  
	}

    private void DispararBala(GameObject brazo, GameObject bala, Transform pos){
        if (balaKetchup){
            if (municionK>0){
                Disparo(bala,pos);
                municionK--;
            }else{
                //manager.ReproducirNoMunicion();
            }
        }else{
            
            if (municionM>0){
                Disparo(bala,pos);
                municionM--;
            }
            else{
                //manager.ReproducirNoMunicion();
            }
        }
    }

    private void Disparo(GameObject bala, Transform pos){
        //manager.ReproducirSonidoBala();

        GameObject ob = Instantiate<GameObject> (bala, pos);
        ob.GetComponent<Rigidbody>().velocity = dis * potenciaDisparo;
        ob.transform.parent = null;

        Destroy(ob,3f);
    }

    private void QuitarVida(){
        vidas--;
        if (vidas <= 0){
            //gameObject.AddComponent<CargadorNiveles>().Cargar("menuPrincipal");
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider col){
        //Debug.Log(col.gameObject.name);
        switch (col.gameObject.name){
            case "municionDoble(Clone)":
                if (municionK != 25 || municionK != 25){
                    municionK = 25;
                    municionM = 25;
                    Destroy(col.gameObject);
                }
                break;
            case "municionK(Clone)":
                if (municionK != 25){
                    municionK = 25;
                    Destroy(col.gameObject);
                }
                break;
            case "municionM(Clone)":
                if (municionM != 25){
                    municionM = 25;
                    Destroy(col.gameObject);
                }
                break;

            case "Zanahoria(Clone)":
            case "Brocoli(Clone)":
            case "Manzana(Clone)":
                QuitarVida();
                Destroy(col.gameObject);
            break;
        }
	}
}