import { React, useState, useEffect } from "react";
import { Button, Modal, ModalOverlay, ModalContent, ModalHeader, ModalBody, OrderedList, ListItem, ModalFooter} from "@chakra-ui/react";

const StepsModal = ({ isOpen, onClose, drinkSteps }) => {

    return (
        <div className='modal'>
        <Modal isOpen={isOpen} onClose={onClose}>
            <ModalOverlay />
            <ModalContent>
            <ModalHeader>{drinkSteps.drinkName}</ModalHeader>
            <ModalBody>
                <OrderedList>
                {drinkSteps.recipeSteps.map((step) => (
                    <ListItem>{step}</ListItem>
                ))}
                </OrderedList>
                
          </ModalBody>
          <ModalFooter>
            <Button colorScheme='blue' mr={3} onClick={onClose}>
              Close
            </Button>
          </ModalFooter>
        </ModalContent>
        </Modal>
        </div>
    );
  };
  
  export default StepsModal;