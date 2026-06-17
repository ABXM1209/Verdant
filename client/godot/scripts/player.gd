class_name Player extends CharacterBody2D

@export var move_speed : float = 500.0

func _ready() -> void:
	var playground = get_tree().get_first_node_in_group("playground")
	if playground:
		position = Vector2(playground.worldWidth / 2.0, playground.worldHeight / 2.0)
		
func _process(delta: float) -> void:
	var direction : Vector2 = Vector2.ZERO
	direction.x = Input.get_action_strength("right") - Input.get_action_strength("left")
	direction.y = Input.get_action_strength("down") - Input.get_action_strength("up")
	
	velocity = direction * move_speed
		
	pass
		
func _physics_process(delta: float) -> void:
	move_and_slide()
	
