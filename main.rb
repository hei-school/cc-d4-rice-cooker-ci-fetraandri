# frozen_string_literal: true

# Simulates a basic rice cooker
class RiceCooker
  COOKING_TIME = 3 # in seconds
  attr_accessor :cooked_rice

  def initialize
    @cooked_rice = false
  end

  def add_rice(amount)
    puts "Adding #{amount} cups of rice to the rice cooker."
  end

  def add_water(_amount)
    puts 'Adding water to the rice cooker.'
  end

  def cook
    if @cooked_rice
      puts 'Rice is already cooked. Reheat if needed.'
    else
      puts 'Cooking the rice...'
      sleep(COOKING_TIME)
      @cooked_rice = true
      puts 'Rice is cooked!'
    end
  end

  def serve
    if @cooked_rice
      puts 'Serving delicious rice!'
      @cooked_rice = false
    else
      puts 'No rice cooked. Please cook first.'
    end
  end
end

# Menu option methods
def menu_add_rice(rice_cooker)
  print 'Enter the amount of rice to add (in cups): '
  amount = gets.chomp.to_i
  if amount.positive?
    rice_cooker.add_rice(amount)
    puts 'Rice added successfully!'
  else
    puts 'Invalid amount. Please enter a positive number.'
  end
end

def menu_add_water(rice_cooker)
  rice_cooker.add_water(nil)
end

def menu_cook(rice_cooker)
  rice_cooker.cook
end

def menu_serve(rice_cooker)
  rice_cooker.serve
end

# Main program
def main
  rice_cooker = RiceCooker.new

  loop do
    display_menu
    choice = user_choice
    process_user_choice(choice, rice_cooker)
    break if choice == 5

    puts 'Press Enter to see the menu again.'
    gets
  end
end

def display_menu
  puts "\nRice Cooker Menu:"
  puts '1. Add rice'
  puts '2. Add water'
  puts '3. Cook'
  puts '4. Serve'
  puts '5. Exit'
end

def user_choice
  print 'Choose an option: '
  gets.chomp.to_i
end

def process_user_choice(choice, rice_cooker)
  case choice
  when 1 then menu_add_rice(rice_cooker)
  when 2 then menu_add_water(rice_cooker)
  when 3 then menu_cook(rice_cooker)
  when 4 then menu_serve(rice_cooker)
  when 5
    puts 'Exiting the rice cooker. Goodbye!'
  else
    puts 'Invalid choice. Please choose a valid option.'
  end
end

main
