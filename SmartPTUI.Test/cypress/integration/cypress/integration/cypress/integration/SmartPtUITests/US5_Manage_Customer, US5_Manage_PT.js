﻿
describe('My First Test', () => {
    it('Does not do much!', () => {
        cy.visit('https://localhost:5001/');
        cy.get('body').click();
        cy.get('#login').click();
        cy.url().should('contains', 'https://localhost:5001/Identity/Account/Login');
        cy.get('#Input_Email').click();
        cy.get('#Input_Email').type('eddietest@test.com');
        cy.get('#Input_Password').click();
        cy.get('#Input_Password').type('Welcome123!');
        cy.get('.col-md-4').click();
        cy.get('.btn').click();
        cy.url().should('contains', 'https://localhost:5001/');
        cy.get('#manage').click();
        cy.url().should('contains', 'https://localhost:5001/Identity/Account/Manage');
        cy.get('#Input_Name').click();
        cy.get('#Input_Name').type('Jim');
        cy.get('#update-profile-button').click();
        cy.url().should('contains', 'https://localhost:5001/Identity/Account/Manage');
        cy.get('#logout').click();
        cy.url().should('contains', 'https://localhost:5001/');
        cy.get('#login').click();
        cy.url().should('contains', 'https://localhost:5001/Identity/Account/Login');
        cy.get('#Input_Email').click();
        cy.get('#Input_Email').type('pttest10@test.com');
        cy.get('#Input_Password').click();
        cy.get('#Input_Password').type('Welcome123!');
        cy.get('.btn').click();
        cy.url().should('contains', 'https://localhost:5001/');
        cy.get('#manage').click();
        cy.url().should('contains', 'https://localhost:5001/Identity/Account/Manage');
        cy.get('#Input_Name').click();
        cy.get('#Input_Name').type('Jim');
        cy.get('#update-profile-button').click();
        cy.url().should('contains', 'https://localhost:5001/Identity/Account/Manage');
        cy.get('#logout').click();
        cy.url().should('contains', 'https://localhost:5001/');

        expect(true).to.equal(true);
    })
})