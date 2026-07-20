class_name EnemyState extends Node

## store reference to the enemy and the state that it belongs to
var enemy : Enemy
var state_machine : EnemyStateMachine

func init()-> void:
	pass

# What happens when the enemy enters this state
func enter() -> void:
	pass
	
# What happens when the player exits the state
func exit()-> void:
	pass
	
# What happens during the _process update in this state
func process(_delta: float) -> EnemyState:
	return null
	
# What happens during the _physics_process update in this state
func physics(_delta: float) -> EnemyState:
	return null
	
