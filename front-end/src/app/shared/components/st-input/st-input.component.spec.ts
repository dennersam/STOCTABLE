import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StInputComponent } from './st-input.component';

describe('StInputComponent', () => {
  let component: StInputComponent;
  let fixture: ComponentFixture<StInputComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ StInputComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(StInputComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
