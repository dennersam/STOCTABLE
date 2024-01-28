import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StBotaoComponent } from './st-botao.component';

describe('StBotaoComponent', () => {
  let component: StBotaoComponent;
  let fixture: ComponentFixture<StBotaoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ StBotaoComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(StBotaoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
