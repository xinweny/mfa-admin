from datetime import date
from uuid import UUID

from sqlalchemy import ForeignKey
from sqlalchemy.orm import Mapped, mapped_column, relationship

from app.database import Base
from app.api.due.constants import PaymentMethod
from app.api.membership.models import Membership

class Due(Base):
    __tablename__ = 'membership_dues'
  
    id: Mapped[UUID] = mapped_column(primary_key=True)
    
    year: Mapped[int]
    payment_method: Mapped[PaymentMethod]
    amount_paid: Mapped[int] = mapped_column(min=20)
    payment_date: Mapped[date | None]
    
    membership_id: Mapped[UUID] = mapped_column(ForeignKey('memberships.id'))
    membership: Mapped[Membership] = relationship(Membership, back_populates='children')