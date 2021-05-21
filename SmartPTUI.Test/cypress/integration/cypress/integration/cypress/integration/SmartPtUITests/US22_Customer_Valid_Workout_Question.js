
describe('My First Test', () => {
    it('Does not do much!', () => {
        cy.visit('https://localhost:5001/');
        cy.get('.p-3').click();
        cy.get('#login').click();
        cy.url().should('contains', 'https://localhost:5001/Identity/Account/Login');
        cy.get('#Input_Email').click();
        cy.get('#Input_Email').type('eddietest@test.com');
        cy.get('#Input_Password').click();
        cy.get('#Input_Password').type('Welcome123!');
        cy.get('.btn').click();
        cy.url().should('contains', 'https://localhost:5001/');
        cy.get('.nav-item:nth-child(4) > .nav-link').click();
        cy.url().should('contains', 'https://localhost:5001/WorkoutQuestionnaire');
        cy.get('#WorkoutQuestion_WorkoutName').click();
        cy.get('#WorkoutQuestion_WorkoutName').type('Cypress');
        cy.get('#WorkoutQuestion_StartWeight').click();
        cy.get('#WorkoutQuestion_StartWeight').type('100');
        cy.get('#WorkoutQuestion_EndWeight').click();
        cy.get('#WorkoutQuestion_EndWeight').type('90');
        cy.get('#WorkoutQuestion_NumberOfWeeks').click();
        cy.get('#WorkoutQuestion_NumberOfWeeks').type('7');
        cy.get('#WorkoutQuestion_DaysPerWeek').click();
        cy.get('#WorkoutQuestion_DaysPerWeek').type('5');
        cy.get('#WorkoutQuestion_TimePerWorkout').click();
        cy.get('#WorkoutQuestion_TimePerWorkout').type('4');
        cy.get('.btn-primary').click();

        cy.url().should('contains', 'https://localhost:5001/Workout');

        expect(true).to.equal(true);
    })
})