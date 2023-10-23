import { React, useState, useEffect } from "react";
import { Button, Checkbox, useDisclosure } from "@chakra-ui/react";
import StepsModal from "./StepsModal";
import axios from "axios";

const DrinksChoice = () => {
  const { isOpen, onOpen, onClose } = useDisclosure();
  const [data, setData] = useState([]);
  const [extras, setExtras] = useState([]);
  const [displayExtras, setDisplayExtras] = useState(false);
  const [drinkId, setDrinkId] = useState();
  const [drinkSteps, setDrinkSteps] = useState();
  const [isDrinkReady, setIsDrinkReady] = useState(false);
  const [selectedExtras, setSelectedExtras] = useState({extraIds: []});

  useEffect(() => {
    axios.get("https://localhost:7175/api/Drinks/getAll").then((res) => {
      setData(res.data);
    });
  }, []);

  function handleClick(id) {
    const url =
      "https://localhost:7175/api/DrinkExtras/getExtras?drinkId=" + id;

    axios
      .get(url)
      .then((response) => {
        setExtras(response.data);
        setDisplayExtras(true);
        setDrinkId(id)
      })
      .catch((err) => {
        console.log(err);
      });
  }

 const onCheckboxChange = (event) => {
    const { value, checked } = event.target; 
    const { extraIds } = selectedExtras; 
    
    if(checked){
      setSelectedExtras({extraIds: [...extraIds, value]})
    }
    else {
      setSelectedExtras({extraIds: extraIds.filter((ex) => ex !== value)})
    }
  }

  function createDrink() {
    var url = "https://localhost:7175/api/RecipeSteps/getSteps?drinkId=" + drinkId
    const { extraIds } = selectedExtras; 
  
    if(extraIds.length)
    {
      extraIds.forEach((extraId) => {
        url = url + "&extraIds=" + extraId;
      });
    }

    axios
      .get(url)
      .then((response) => {
        setDrinkSteps(response.data)
        setIsDrinkReady(true)
        onOpen()
      })
      .catch((err) => {
        console.log(err);
      });
  }

  return (
    <div>
      {isDrinkReady && <StepsModal isOpen={isOpen} onClose={onClose} drinkSteps={drinkSteps}/>}
      <div className="buttonsContainer">
        {data.map((drink) => (
          <Button colorScheme="teal" variant="outline" onClick={() => handleClick(drink.id)}>
            {drink.name}
          </Button>
        ))}
      </div>
      <div className="extrasChoice">
        {displayExtras && (
          <div>
            <div>
              {extras.drinkExtras.map((extra) => (
                <Checkbox colorScheme="yellow" padding="10px" value={extra.id} onChange={onCheckboxChange}>
                  {extra.name}
                </Checkbox>
              ))}
            </div>
            <div>
              <Button colorScheme="teal" variant="solid" onClick={createDrink}>Create Drink!</Button>
            </div>
          </div>
        )}
      </div>
    </div>
  );
};

export default DrinksChoice;
