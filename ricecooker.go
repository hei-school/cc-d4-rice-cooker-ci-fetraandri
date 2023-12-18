package main

import (
	"fmt"
	"time"
)

// RiceCooker structure
type RiceCooker struct {
	CookedRice bool
}

// AddRice method
func (rc *RiceCooker) AddRice(amount int) {
	fmt.Printf("Adding %d cups of rice to the rice cooker.\n", amount)
}

// AddWater method
func (rc *RiceCooker) AddWater() {
	fmt.Println("Adding water to the rice cooker.")
}

// Cook method
func (rc *RiceCooker) Cook() {
	if rc.CookedRice {
		fmt.Println("Rice is already cooked. Reheat if needed.")
	} else {
		fmt.Println("Cooking the rice...")
		time.Sleep(3 * time.Second)
		rc.CookedRice = true
		fmt.Println("Rice is cooked!")
	}
}

// Serve method
func (rc *RiceCooker) Serve() {
	if rc.CookedRice {
		fmt.Println("Serving delicious rice!")
		rc.CookedRice = false
	} else {
		fmt.Println("No rice cooked. Please cook first.")
	}
}

// DisplayMenu function
func DisplayMenu() {
	fmt.Println("\nRice Cooker Menu:")
	fmt.Println("1. Add rice")
	fmt.Println("2. Add water")
	fmt.Println("3. Cook")
	fmt.Println("4. Serve")
	fmt.Println("5. Exit")
}

// UserChoice function
func UserChoice() (int, error) {
	var choice int
	fmt.Print("Choose an option: ")
	_, err := fmt.Scan(&choice)
	return choice, err
}

// ProcessUserChoice function
func ProcessUserChoice(choice int, rc *RiceCooker) {
	switch choice {
	case 1:
		var amount int
		fmt.Print("Enter the amount of rice to add (in cups): ")
		_, err := fmt.Scan(&amount)
		if err != nil {
			fmt.Println("Error reading input:", err)
			return
		}
		rc.AddRice(amount)
		fmt.Println("Rice added successfully!")
	case 2:
		rc.AddWater()
	case 3:
		rc.Cook()
	case 4:
		rc.Serve()
	case 5:
		fmt.Println("Exiting the rice cooker. Goodbye!")
	default:
		fmt.Println("Invalid choice. Please choose a valid option.")
	}
}

func main() {
	riceCooker := RiceCooker{}

	for {
		DisplayMenu()
		choice, err := UserChoice()
		if err != nil {
			fmt.Println("Error reading input:", err)
			break
		}

		ProcessUserChoice(choice, &riceCooker)
		if choice == 5 {
			break
		}

		fmt.Println("Press Enter to see the menu again.")
		fmt.Scanln()
	}
}
