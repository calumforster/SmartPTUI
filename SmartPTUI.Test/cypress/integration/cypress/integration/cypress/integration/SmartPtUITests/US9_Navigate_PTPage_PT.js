
describe('US1_Customer_Registration', () => {
    it('Registers Customer', () => {
        cy.visit('https://localhost:5001/');
        cy.get('body').click();
        cy.get('#login').click();
        cy.url().should('contains', 'https://localhost:5001/Identity/Account/Login');
        cy.get('#Input_Email').click();
        cy.get('#Input_Email').click();
        cy.get('body').click();
        cy.get('#Input_Email').type('eddietest@test.com');
        cy.get('#Input_Password').click();
        cy.get('#Input_Password').type('Welcome123!');
        cy.get('.btn').click();
        cy.url().should('contains', 'https://localhost:5001/');
        cy.get('.nav-item:nth-child(5) > .nav-link').click();
        cy.url().should('contains', 'https://localhost:5001/WorkoutQuestionnaire');
        cy.get('.nav-item:nth-child(4) > .nav-link').click();
        cy.url().should('contains', 'https://localhost:5001/Dashboard');
        cy.get('#logout').click();
        cy.url().should('contains', 'https://localhost:5001/');
        expect(true).to.equal(true);
    })
})

