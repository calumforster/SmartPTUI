var hashNo = Math.random() * (20000 - 1) + 1;

describe('My First Test', () => {
    it('Does not do much!', () => {
        cy.visit('https://localhost:5001/');
        cy.get('.flex-grow-1').click();
        cy.get('#register').click();
        cy.url().should('contains', 'https://localhost:5001/Identity/Account/Register');
        cy.get('#Input_FirstName').click();
        cy.get('#Input_FirstName').type('Cypress');
        cy.get('#Input_LastName').type('Test');
        cy.get('#Input_Gender').select('Male');
        cy.get('#Input_Height').click();
        cy.get('#Input_Height').type('180');
        cy.get('#Input_CurrentHealthRating').select('Good');
        cy.get('#Input_DOB').click();
        cy.get('#Input_DOB').type('1990-09-19');
        cy.get('#Input_Email').click();
        cy.get('#Input_Email').type('cypresstest' + hashNo+'@test.com');
        cy.get('#Input_Password').click();
        cy.get('#Input_Password').type('Welcome123!');
        cy.get('#Input_ConfirmPassword').click();
        cy.get('#Input_ConfirmPassword').type('Welcome123!');
        cy.get('.btn').click();
        cy.get('form').submit();
        cy.url().should('contains', 'https://localhost:5001/');
    })
})