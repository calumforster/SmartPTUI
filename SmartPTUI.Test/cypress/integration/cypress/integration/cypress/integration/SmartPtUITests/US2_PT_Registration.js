
var hashNo = Math.random() * (20000 - 1) + 1;
describe('My First Test', () => {
    it('Does not do much!', () => {
        cy.visit('https://localhost:5001/');
        cy.get('body').click();
        cy.get('#pt-register').click();
        cy.url().should('contains', 'https://localhost:5001/Identity/Account/PtRegister');
        cy.get('#Input_FirstName').click();
        cy.get('#Input_FirstName').type('Cypress');
        cy.get('#Input_LastName').type('Test');
        cy.get('#Input_Gender').select('0');
        cy.get('#Input_DOB').click();
        cy.get('#Input_DOB').type('1990-09-19');
        cy.get('#Input_CustomerEmail').click();
        cy.get('#Input_CustomerEmail').type('eddietest@test.com');
        cy.get('#Input_TitleColour').click();
        cy.get('#Input_TitleColour').type('#ffffff');
        cy.get('.form-group:nth-child(15)').click();
        cy.get('#Input_TextColour').click();
        cy.get('#Input_TextColour').type('#ffffff');
        cy.get('#Input_BackgroundColour').click();
        cy.get('#Input_BackgroundColour').type('#ffffff');
        cy.get('#Input_TopBarColour').click();
        cy.get('#Input_TopBarColour').type('#ffffff');
        cy.get('#Input_SiteName').click();
        cy.get('#Input_SiteName').type('Cypress');
        cy.get('#Input_WelcomeMessage').click();
        cy.get('#Input_WelcomeMessage').type('Cypress');
        cy.get('#Input_Email').click();
        cy.get('#Input_Email').type('cypresstest' + hashNo + '@test.com');
        cy.get('#Input_Password').click();
        cy.get('#Input_Password').type('Welcome123!');
        cy.get('#Input_ConfirmPassword').click();
        cy.get('#Input_ConfirmPassword').type('Welcome123!');
        cy.get('.btn').click();
        cy.get('form').submit();
        cy.url().should('contains', 'https://localhost:5001/');

        expect(true).to.equal(true);
    })
})
