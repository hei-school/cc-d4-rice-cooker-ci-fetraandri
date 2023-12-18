# frozen_string_literal: true

require 'minitest/autorun'
require_relative 'main' 

class RiceCookerTest < Minitest::Test
  def setup
    @rice_cooker = RiceCooker.new
  end

  def test_add_rice
    assert_output("Adding 2 cups of rice to the rice cooker.\nRice added successfully!\n") do
      @rice_cooker.add_rice(2)
    end
  end

  def test_add_water
    assert_output("Adding water to the rice cooker.\n") do
      @rice_cooker.add_water(nil)
    end
  end

  def test_cook
    assert_output("Cooking the rice...\nRice is cooked!\n") do
      @rice_cooker.cook
    end
    assert @rice_cooker.cooked_rice
  end

  def test_serve
    @rice_cooker.cook
    assert_output("Serving delicious rice!\n") do
      @rice_cooker.serve
    end
    refute @rice_cooker.cooked_rice
  end
end
