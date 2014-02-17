#pragma strict

var explosionPrefab : Transform;

function OnCollisionEnter(collision : Collision) { // Rotate the object so that the y-axis faces along the normal of the surface 
var contact : ContactPoint = collision.contacts[0]; 
var rot : Quaternion = Quaternion.FromToRotation(Vector3.up, contact.normal); 
var pos : Vector3 = contact.point; Instantiate(explosionPrefab, pos, rot); // Destroy the projectile Destroy (gameObject);
}